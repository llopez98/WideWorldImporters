using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Warehouse.Repository
{
    public interface IWarehouseRepository
    {
        Task<List<StockItemsDto>> GetAllStockItems();

        Task<List<StockItemTransactionDto>> GetStockItemTransactions(int id);

        Task NewStockItem(StockItem item);
    }
}
