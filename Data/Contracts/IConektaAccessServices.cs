namespace Data.Contracts
{
    using Common.Models;
    using Common.Models.Conekta;

    public interface IConektaAccessServices
    {
        Task<ManagerResult<ConektaClienteModel>> PostCliente(ConektaCreateClienteModel model);

        Task<ManagerResult<ConektaClienteModel>> GetCliente(string customerId);

        Task<ManagerResult<ConektaTokenResponseModel>> PostToken(ConektaSearchTokenModel model);

        Task<ManagerResult<ConektaCardResponseModel>> PostCard(string customerId, ConektaCreateCardModel model);

        Task<ManagerResult<ConektaOrderResponseModel>> PostOrder(ConektaOrderModel model);
    }
}
