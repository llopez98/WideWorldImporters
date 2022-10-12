using AutoMapper;
using Entities.Context;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WideWorldImporters.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly WideWorldImportersStandardContext _context;
        private readonly IMapper _mapper;

        public ApplicationRepository(WideWorldImportersStandardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomersDto>> GetAllCustomers()
        {
            var customers = await _context.Customers1.ToListAsync();
            var customersDto = _mapper.Map<List<Customer1>, List<CustomersDto>>(customers);

            return customersDto;
        }

        public async Task<CustomerDto> GetCustomer(int id)
        {
            var customer = await _context.Customers1.FirstOrDefaultAsync(x => x.CustomerId == id);
            var customerDto = _mapper.Map<Customer1, CustomerDto>(customer);

            return customerDto;
        }

        public async Task<List<CustomerTransactionDto>> GetCustomerTransactions(int id)
        {
            var customerTransactions = await _context.CustomerTransactions
                .Where(x => x.CustomerId == id)
                .ToListAsync();

            var customerTransactionsDto = _mapper.Map<
                List<CustomerTransaction>,
                List<CustomerTransactionDto>
            >(customerTransactions);

            return customerTransactionsDto;
        }

        public async Task<List<CustomerOrdersDto>> GetCustomerOrders(int id)
        {
            var orders = await _context.Orders.Where(x => x.CustomerId == id).ToListAsync();

            var customerOrders = _mapper.Map<List<Order>, List<CustomerOrdersDto>>(orders);

            return customerOrders;
        }

        public async Task<OrderDetailsDto> GetOrderDetails(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            var orderDetailsDto = _mapper.Map<Order, OrderDetailsDto>(order);

            var lines = await _context.OrderLines.Where(x => x.OrderId == id).ToListAsync();

            var linesDto = _mapper.Map<List<OrderLine>, List<OrderLinesDto>>(lines);

            var contactPerson = await _context.People
                .Where(x => x.PersonId == order.ContactPersonId)
                .FirstOrDefaultAsync();
            if (contactPerson != null)
                orderDetailsDto.ContactPerson = contactPerson.FullName;

            var pickedbyPerson = await _context.People
                .Where(x => x.PersonId == order.PickedByPersonId)
                .FirstOrDefaultAsync();
            if (pickedbyPerson != null)
                orderDetailsDto.PickedByPerson = pickedbyPerson.FullName;

            var salesPerson = await _context.People
                .Where(x => x.PersonId == order.SalespersonPersonId)
                .FirstOrDefaultAsync();
            if (salesPerson != null)
                orderDetailsDto.SalespersonPerson = salesPerson.FullName;

            foreach (var line in linesDto)
            {
                orderDetailsDto.OrderLines.Add(line);
            }

            return orderDetailsDto;
        }

        public async Task NewCustomer(Customer customer)
        {
            /*
             {
                "CustomerName": "CustomerTest1",
                "BillToCustomerID": 1,
                "CustomerCategoryID": 3,
                "PrimaryContactPersonID": 1009,
                "DeliveryMethodID": 3,
                "DeliveryCityID": 19586,
                "PostalCityID": 19586,
                "AccountOpenedDate": "2022-01-01",
                "StandardDiscountPercentage": 0,
                "IsStatementSent": 0,
                "IsOnCreditHold": 0,
                "PaymentDays": 7,
                "PhoneNumber": "(507)555-0101",
                "FaxNumber": "(507)555-0101",
                "WebsiteURL": "http://www.test1.com",
                "DeliveryAddressLine1": "Shop 41",
                "DeliveryPostalCode": "90410",
                "PostalAddressLine1": "PO Box 259",
                "PostalPostalCode": "90216",
                "LastEditedBy": 1
            }
             */
            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task NewCustomerOrder(Order order)
        {
            /*
             {
                "CustomerID": 832,
	            "SalespersonPersonID": 2,
	            "ContactPersonID": 3032,
	            "OrderDate": "2022-01-01",
	            "ExpectedDeliveryDate": "2022-01-02",
	            "IsUndersupplyBackordered": 1,
	            "LastEditedBy": 7
            }
             */
            try
            { 
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }catch (Exception e) { 
                throw new Exception(e.Message);
            }
        }
    }
}
