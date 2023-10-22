using CoachPlan.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CoachPlan.gRPC.Infrastructure;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            var log = scope.ServiceProvider.GetRequiredService<ILogger<CoachPlanContext>>();

            using (var appContext = scope.ServiceProvider.GetRequiredService<CoachPlanContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    log.LogError($"Error migrating the database: {ex.Message}");
                }
            }
        }

        return webApp;
    }
}