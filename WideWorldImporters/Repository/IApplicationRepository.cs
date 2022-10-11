using Entities.Dto;
using Entities.Models;

namespace WideWorldImporters.Repository
{
    public interface IApplicationRepository
    {
        Task<CustomerDto> GetCustomer(int id);

        Task<List<CustomersDto>> GetAllCustomers();

        Task<List<CustomerTransactionDto>> GetCustomerTransactions(int id);

        Task<List<CustomerOrdersDto>> GetCustomerOrders(int id);

        Task<OrderDetailsDto> GetOrderDetails(int id);
    }
}
