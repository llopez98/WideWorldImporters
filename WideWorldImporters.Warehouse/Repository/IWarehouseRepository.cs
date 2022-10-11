using Entities.Dto;

namespace WideWorldImporters.Warehouse.Repository
{
    public interface IWarehouseRepository
    {
        Task<List<StockItemsDto>> GetAllStockItems();

        Task<List<StockItemTransactionDto>> GetStockItemTransactions(int id);
    }
}
