using Accounts.Database;
using Microsoft.EntityFrameworkCore;

namespace Accounts
{

    public static class Config
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration config)
        {
            //AddDbContext<AccountsDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
            return services.AddDbContext<AccountsDbContext>(
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
