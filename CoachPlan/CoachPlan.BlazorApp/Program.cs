using CoachPlan.BlazorApp;
using CoachPlan.BlazorApp.Services;
using CoachPlan.Domain.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IMuscleService, MuscleService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7218/");
});

await builder.Build().RunAsync();
