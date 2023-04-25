using Microsoft.EntityFrameworkCore;
using PositionKeeping.Database;

namespace PositionKeeping
{

    public static class Config
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration config)
        {
            //AddDbContext<AccountsDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
            return services.AddDbContext<PositionKeepingDB>(
                options =>
                {
                    var schemaName = Environment.GetEnvironmentVariable("SchemaName")!;
                    var connectionString = config.GetConnectionString("AccountDatabase");

                    options.UseSqlServer(connectionString);
                    

                    /*
                    options.UseNpgsql(
                        $"{connectionString}; searchpath = {schemaName.ToLower()}",
                        x => x.MigrationsHistoryTable("__EFMigrationsHistory", schemaName.ToLower()));
                    */

                });
        }

    }
}
