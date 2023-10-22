using CoachPlan.gRPC.Services;
using CoachPlan.Data.Context;
using CoachPlan.Data.Repositories;
using CoachPlan.Domain.Repositories;
using CoachPlan.Service.Services;
using Microsoft.EntityFrameworkCore;
using CoachPlan.Domain.Services;
using CoachPlan.gRPC.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(5287, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});

builder.Services.AddDbContext<CoachPlanContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMuscleRepository, MuscleRepository>();
builder.Services.AddScoped<IMuscleService, CoachPlan.Service.Services.MuscleService>();       

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<CoachPlanService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MigrateDatabase();

app.Run();
