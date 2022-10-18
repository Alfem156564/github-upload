namespace Core.Contracts
{
    using Common.Models;
    using Common.Models.Conekta;

    public interface IConektaManager
    {
        Task<ManagerResult<ConektaClienteModel>> PostCliente(ConektaCreateClienteModel model);

        Task<ManagerResult<ConektaClienteModel>> GetCliente(string customerId);

        Task<ManagerResult<ConektaTokenResponseModel>> PostToken(ConektaSearchTokenModel model);
    }
}
