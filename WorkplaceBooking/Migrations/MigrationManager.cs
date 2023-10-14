using FluentMigrator.Runner;
using WorkplaceBooking.Exceptions;

namespace WorkplaceBooking.Migrations
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                try
                {
                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch
                {
                    throw new AppException("Failed migrate database");
                }
            }
            return host;
        }
    }
}
