namespace Core.Managers
{
    using Common.Models;
    using Common.Models.Conekta;
    using Core.Contracts;
    using Data.Contracts;

    public class ConektaManager : IConektaManager
    {
        private readonly IConektaAccessServices conektaAccessServices;

        public ConektaManager(IConektaAccessServices conektaAccessServices)
        {
            this.conektaAccessServices = conektaAccessServices;
        }

        public Task<ManagerResult<ConektaClienteModel>> PostCliente(ConektaCreateClienteModel model) =>
            conektaAccessServices
                .PostCliente(model);

        public Task<ManagerResult<ConektaClienteModel>> GetCliente(string customerId) =>
            conektaAccessServices
            .GetCliente(customerId);

        public Task<ManagerResult<ConektaTokenResponseModel>> PostToken(ConektaSearchTokenModel model) =>
            conektaAccessServices
            .PostToken(model);
    }
}
