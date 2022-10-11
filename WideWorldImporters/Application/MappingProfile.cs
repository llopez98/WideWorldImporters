using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Customer1, CustomersDto>();
            CreateMap<Customer1, CustomerDto>();
            CreateMap<CustomerTransaction, CustomerTransactionDto>();
            CreateMap<Order, CustomerOrdersDto>();
            CreateMap<OrderLine, OrderLinesDto>();
            CreateMap<Order, OrderDetailsDto>();
        }
    }
}
