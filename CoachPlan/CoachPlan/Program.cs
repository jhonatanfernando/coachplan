using AspNetCoreRateLimit;
using CoachPlan.Data.Context;
using CoachPlan.Data.Repositories;
using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using CoachPlan.Domain.Services;
using CoachPlan.Features.Muscle.Command;
using CoachPlan.Features.Muscle.Query;
using CoachPlan.RateLimiting;
using CoachPlan.Service.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// needed to store rate limit counters and ip rules
builder.Services.AddMemoryCache();

//load general configuration from appsettings.json
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

//load ip rules from appsettings.json
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

// configure client rate limiting middleware
//builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
//builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));


// inject counter and rules stores    
builder.Services.AddInMemoryRateLimiting();

// configuration (resolvers, counter key builders)
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
//builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IRateLimitConfiguration, CustomRateLimitConfiguration>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IMuscleRepository, MuscleRepository>();
builder.Services.AddScoped<IMuscleService, MuscleService>();

builder.Services.AddDbContext<CoachPlanContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/status", () =>
{
    return "Running";
});

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
