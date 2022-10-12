using AutoMapper;
using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WorldWideImporters.Purchasing.Context;

namespace WideWorldImporters.Purchasing.Repository
{
    public class PurchasingRepository : IPurchasingRepository
    {
        private readonly WideWorldImportersStandardContext _context;
        private readonly IMapper _mapper;

        public PurchasingRepository(WideWorldImportersStandardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> GetAllSupplier()
        {
            var supplier = await _context.Suppliers1.ToListAsync();

            var supplierDto = _mapper.Map<List<Supplier1>, List<SupplierDto>>(supplier);

            return supplierDto;
        }

        public async Task<List<PurchasingOrdersDto>> GetPurchasingOrders(int id)
        {
            var orders = await _context.PurchaseOrders.Where(x => x.SupplierId == id).ToListAsync();

            var ordersDto = _mapper.Map<List<PurchaseOrder>, List<PurchasingOrdersDto>>(orders);

            foreach (var order in ordersDto)
            {
                var orderLines = await _context.PurchaseOrderLines
                    .Where(x => x.PurchaseOrderId == order.PurchaseOrderId)
                    .ToListAsync();
                var orderLinesDto = _mapper.Map<
                    List<PurchaseOrderLine>,
                    List<PurchaseOrderLineDto>
                >(orderLines);

                order.PurchaseOrderLines = orderLinesDto;

                //nombres

                var delivery = _context.DeliveryMethods.Find(order.DeliveryMethodId);
                order.DeliveryMethodName = delivery.DeliveryMethodName;

                var contact = _context.People.Find(order.ContactPersonId);
                order.ContactPersonName = contact.FullName;
            }

            return ordersDto;
        }

        public async Task<List<SupplierTransactionsDto>> GetSupplierTransactions(int id)
        {
            var transactions = await _context.SupplierTransactions
                .Where(x => x.SupplierId == id)
                .ToListAsync();

            var transactionsDto = _mapper.Map<
                List<SupplierTransaction>,
                List<SupplierTransactionsDto>
            >(transactions);

            foreach (var transaction in transactions)
            {
                foreach (var tranDto in transactionsDto)
                {
                    var payment = _context.PaymentMethods.Find(transaction.PaymentMethodId);
                    var trantype = _context.TransactionTypes.Find(transaction.TransactionTypeId);
                    tranDto.PaymentMethod = payment.PaymentMethodName;
                    tranDto.TransactionType = trantype.TransactionTypeName;
                }
            }

            return transactionsDto;
        }

        public async Task NewPurchaseOrder(PurchaseOrder order)
        {
            try { 
                _context.PurchaseOrders.Add(order);
                await _context.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public async Task NewSupplier(Supplier supplier)
        {
            /*
             {
                "SupplierName": "SupplierTest1",
                "SupplierCategoryID": 2,
                "PrimaryContactPersonID": 21,
                "AlternateContactPersonID": 22,
                "DeliveryCityID": 7,
                "PostalCityID": 38171,
                "PaymentDays": 14,
                "PhoneNumber": "(507)555-0100",
                "FaxNumber": "(507)555-0100",
                "WebsiteURL": "www.suppliertestweb.com",
                "DeliveryAddressLine1": "Unit 12",
                "DeliveryPostalCode": "46077",
                "PostalAddressLine1": "PO Box 1039",
                "PostalPostalCode": "46077",
                "LastEditedBy": 1
                }
             */
            try
            {
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
