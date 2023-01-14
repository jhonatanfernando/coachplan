using CoachPlan.Data.Context;
using CoachPlan.Data.Repositories;
using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using CoachPlan.Domain.Services;
using CoachPlan.Features.Muscle.Command;
using CoachPlan.Features.Muscle.Query;
using CoachPlan.Service.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IMuscleRepository, MuscleRepository>();
builder.Services.AddScoped<IMuscleService, MuscleService>();

builder.Services.AddDbContext<CoachPlanContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/muscles", async (IMediator _mediator) =>
{
    return await _mediator.Send(new GetAllMusclesQuery());
});

app.MapGet("/muscles/{id}", async (IMediator _mediator, int id) =>
{
    return await _mediator.Send(new GetMuscleByIdQuery(id));
});

app.MapPost("/muscles", async (IMediator _mediator, Muscle muscle) =>
{
   await _mediator.Send(new CreateMuscleCommand(muscle));

    return Results.Created($"/muscles/{muscle.Id}", muscle);
});

app.MapPut("/muscles/{id}", async (IMediator _mediator, int id, Muscle muscle) =>
{
    await _mediator.Send(new UpdateMuscleCommand(id, muscle));

    return Results.NoContent();
});

app.MapDelete("/muscles/{id}", async (IMediator _mediator, int id) =>
{
    await _mediator.Send(new DeleteMuscleCommand(id));

    return Results.Ok();
});

app.Run();
