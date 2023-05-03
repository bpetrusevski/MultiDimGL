using MDGeneralLedger.Database;
using Microsoft.EntityFrameworkCore;

namespace MDGeneralLedger
{

    public static class Config
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration config)
        {
            //AddDbContext<AccountsDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
            return
                services.AddDbContext<GeneralLedgerDB>(
                    options =>
                    {
                        //var schemaName = Environment.GetEnvironmentVariable("SchemaName")!;
                        var connectionString = config.GetConnectionString("GLDatabase");

                        //options.EnableServiceProviderCaching(false);
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
