namespace Testing.Functions.Base
{
    using Data.AccessServices;
    using Data.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using System;

    public class TestBase
    {
        private ServiceProvider serviceProvider;

        private ServiceCollection services = new ServiceCollection();


        #region DataProviders

        protected Mock<IDatabaseContext> databaseContextMock;

        protected IDatabaseContext? databaseContextProvider => serviceProvider?.GetService<IDatabaseContext>();

        #endregion

        #region DataProviders

        protected IUserTypeAccessServices? userTypeAccessServiceProvider => serviceProvider?.GetService<IUserTypeAccessServices>();
        #endregion

        public TestBase()
        {
            InitializeDatabaseContextMock();
            InitializeServices();
        }

        public TService? GetService<TService>() where TService : class
        {
            return serviceProvider?
                .GetService<TService>();
        }

        public void RegisterService<TService, TImplementation>() where TService : class
            where TImplementation : class, TService
        {
            services.AddScoped<TService, TImplementation>();
        }

        public void RegisterService<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services.AddScoped(implementationFactory);
        }

        public void RegisterService<TService, TImplementation>(Func<IServiceProvider, TService> implementationFactory) where TService : class
        {
            services.AddScoped(implementationFactory);
        }

        protected virtual void InitializeServices()
        {

            InitializeDataProviders(services);
            InitializeDataAccessProviders(services);

            serviceProvider = services.BuildServiceProvider();
        }

        protected virtual void InitializeDatabaseContextMock()
        {
            databaseContextMock = new Mock<IDatabaseContext>();
        }

        private void InitializeDataProviders(ServiceCollection services)
        {
            if (databaseContextProvider == null) services.AddScoped(x => databaseContextMock.Object);
        }

        private void InitializeDataAccessProviders(ServiceCollection services)
        {
            if (userTypeAccessServiceProvider == null) services.AddScoped<IUserTypeAccessServices, UserTypeAccessServices>();
        }
    }
}
