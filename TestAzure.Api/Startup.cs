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
    using TestAzure.Api.Definition.Error;
    using TestAzure.Api.Functions.Graphql.Type;
    using TestAzure.Api.Functions.Graphql;

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
                .AddSingleton(x => configuration)
                .AddGraphQLFunction()
                .AddType<OfferType>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddErrorFilter(error => {
                    if (error.Exception is ApiException)
                    {
                        var apiException = (ApiException)error.Exception;
                        return error
                            .WithCode(apiException.ErrorCode.ToString())
                            .WithMessage(apiException.ErrorMessage)
                            .RemoveExtensions()
                            .RemoveLocations();
                    }

                    return error;
                }); ;

            AddDataProviders(builder.Services);
            AddDataAccessService(builder.Services);
            AddManagers(builder.Services);
        }

        private void AddDataProviders(IServiceCollection services)
        {
            services
                .AddDbContext<IDatabaseContext, DatabaseContext>(options =>
                    options.UseSqlServer(configuration.DatabaseConnectionString))
                .AddDbContext<GraphDatabaseContext>(options =>
                    options.UseSqlServer(configuration.DatabaseConnectionString))
                .AddDbContext<PasatiempoDatabaseContext>(options =>
                    options.UseSqlServer(configuration.DatabaseConnectionString));
        }

        private void AddDataAccessService(IServiceCollection services)
        {
            services
                .AddScoped<ICertificatesCounterOfferDataAccessService, CertificatesCounterOfferDataAccessService>()
                .AddScoped<ICertificatesOfferAccessService, CertificatesOfferAccessService>()
                .AddScoped<IEnergyOfferAccessService, EnergyOfferAccessService>()
                .AddScoped<IUserTypeAccessServices, UserTypeAccessServices>()
                .AddScoped<ICatalogoDestinoAccessServices, CatalogoDestinoAccessServices>();
        }

        private void AddManagers(IServiceCollection services)
        {
            services
                .AddScoped<IUserTypeManager, UserTypeManager>();
        }
    }
}