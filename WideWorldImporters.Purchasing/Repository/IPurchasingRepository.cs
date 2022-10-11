using Entities.Dto;

namespace WideWorldImporters.Purchasing.Repository
{
    public interface IPurchasingRepository
    {
        Task<List<SupplierDto>> GetAllSupplier();

        Task<List<SupplierTransactionsDto>> GetSupplierTransactions(int id);

        Task<List<PurchasingOrdersDto>> GetPurchasingOrders(int id);
    }
}
