using Furion;
using Furion.DatabaseAccessor;
using Microsoft.Extensions.DependencyInjection;

namespace FurionTemplate.DbManager
{
    [AppStartup(600)]
    public sealed class DbManagerStartup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<DefaultDbContext>(DbProvider.Sqlite);
            }, "FurionTemplate.Migrations");
        }
    }
}