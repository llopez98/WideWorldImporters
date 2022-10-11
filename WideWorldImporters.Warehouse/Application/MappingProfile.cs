using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Warehouse.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Customer1, CustomerDto>();
            CreateMap<PurchaseOrder, PurchasingOrdersDto>();
            CreateMap<Supplier1, SupplierDto>();
            CreateMap<StockItem, StockItemsDto>();
            CreateMap<StockItemTransaction, StockItemTransactionDto>();
        }
    }
}
