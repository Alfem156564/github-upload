using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(TestAzure.Api.Startup))]
namespace TestAzure.Api
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using Data.Contracts;
    using Data.Providers.Database;
    using Data.AccessServices;
    using Core.Contracts;
    using Core.Managers;

    public class Startup : FunctionsStartup
    {
        private readonly ITestAzureConfig configuration;

        public Startup()
        {
            this.configuration = new TestAzureConfig();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddSingleton(x => configuration);

            AddDataProviders(builder.Services);
            AddDataAccessService(builder.Services);
            AddManagers(builder.Services);
        }

        private void AddDataProviders(IServiceCollection services)
        {
            services
                .AddDbContext<IDatabaseContext, DatabaseContext>(options =>
                    options.UseSqlServer(configuration.DatabaseConnectionString));
        }

        private void AddDataAccessService(IServiceCollection services)
        {
            services
                .AddScoped<IUserTypeAccessServices, UserTypeAccessServices>();
        }

        private void AddManagers(IServiceCollection services)
        {
            services
                .AddScoped<IUserTypeManager, UserTypeManager>();
        }
    }
}