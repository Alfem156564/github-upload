namespace Testing.Functions.Base
{
    using Core.Contracts;
    using Core.Managers;

    public class FunctionsTestBase : TestBase
    {

        #region Managers
        protected IUserTypeManager? userTypeManagerProvider => GetService<IUserTypeManager>();

        #endregion

        protected override void InitializeServices()
        {
            InitializeManagers();
            base.InitializeServices();
        }

        private void InitializeManagers()
        {
            if (userTypeManagerProvider == null) RegisterService<IUserTypeManager, UserTypeManager>(x => new UserTypeManager(userTypeAccessServiceProvider));
        }
    }
}
