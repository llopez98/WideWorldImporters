using AutoMapper;
using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WideWorldImporters.Warehouse.Context;

namespace WideWorldImporters.Warehouse.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly WideWorldImportersStandardContext _context;
        private readonly IMapper _mapper;

        public WarehouseRepository(WideWorldImportersStandardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StockItemsDto>> GetAllStockItems()
        {
            var stockItems = await _context.StockItems.ToListAsync();

            var stockItemsDto = _mapper.Map<List<StockItem>, List<StockItemsDto>>(stockItems);

            return stockItemsDto;
        }

        public async Task<List<StockItemTransactionDto>> GetStockItemTransactions(int id)
        {
            var stockItemsTrans = await _context.StockItemTransactions
                .Where(x => x.StockItemId == id)
                .Take(5)
                .ToListAsync();

            var stockItemsTransDto = _mapper.Map<
                List<StockItemTransaction>,
                List<StockItemTransactionDto>
            >(stockItemsTrans);

            foreach (var item in stockItemsTransDto)
            {
                var customer = await _context.Customers1
                    .Where(x => x.CustomerId == item.CustomerId)
                    .FirstOrDefaultAsync();
                item.Customer = _mapper.Map<Customer1, CustomerDto>(customer);

                var purchaseOrder = await _context.PurchaseOrders
                    .Where(x => x.PurchaseOrderId == item.PurchaseOrderId)
                    .FirstOrDefaultAsync();
                item.PurchaseOrder = _mapper.Map<PurchaseOrder, PurchasingOrdersDto>(purchaseOrder);

                var stockItem = await _context.StockItems
                    .Where(x => x.StockItemId == item.StockItemId)
                    .FirstOrDefaultAsync();
                item.StockItem = _mapper.Map<StockItem, StockItemsDto>(stockItem);

                var supplier = await _context.Suppliers1
                    .Where(x => x.SupplierId == item.SupplierId)
                    .FirstOrDefaultAsync();
                item.Supplier = _mapper.Map<Supplier1, SupplierDto>(supplier);
            }

            return stockItemsTransDto;
        }

        public async Task NewStockItem(StockItem item)
        {
            try
            {
                /*
                 {
                    "StockItemName": "TestItem2",
                    "SupplierID": 12,
                    "UnitPackageID": 7,
                    "OuterPackageID": 7,
                    "LeadTimeDays": 15,
                    "QuantityPerOuter": 1,
                    "IsChillerStock": 0,
                    "TaxRate": 15,
                    "UnitPrice": 100,
                    "TypicalWeightPerUnit": 15,
                    "LastEditedBy": 1
                }
                 */
                _context.StockItems.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteStockItem(int id)
        {
            try {
                var stockItem = _context.StockItems.FindAsync(id);
                _context.Remove(stockItem);
                await _context.SaveChangesAsync();
            } catch (Exception e) { 
                throw new Exception(e.Message);
            }
        }
    }
}
