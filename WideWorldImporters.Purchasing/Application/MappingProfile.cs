using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Purchasing.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Supplier1, SupplierDto>();
            CreateMap<SupplierTransaction, SupplierTransactionsDto>();
            CreateMap<PurchaseOrder, PurchasingOrdersDto>();
            CreateMap<PurchaseOrderLine, PurchaseOrderLineDto>();
        }
    }
}
