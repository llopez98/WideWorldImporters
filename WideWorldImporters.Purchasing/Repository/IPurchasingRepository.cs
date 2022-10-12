using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Purchasing.Repository
{
    public interface IPurchasingRepository
    {
        Task<List<SupplierDto>> GetAllSupplier();

        Task<List<SupplierTransactionsDto>> GetSupplierTransactions(int id);

        Task<List<PurchasingOrdersDto>> GetPurchasingOrders(int id);

        Task NewSupplier(Supplier supplier);

        Task NewPurchaseOrder(PurchaseOrder order);
    }
}
