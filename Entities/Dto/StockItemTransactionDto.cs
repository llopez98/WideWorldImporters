using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class StockItemTransactionDto
    {
        public int StockItemTransactionId { get; set; }
        public int StockItemId { get; set; }
        public int? CustomerId { get; set; }
        public int? SupplierId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }

        public virtual CustomerDto? Customer { get; set; }
        public virtual PurchasingOrdersDto? PurchaseOrder { get; set; }
        public virtual StockItemsDto StockItem { get; set; } = null!;
        public virtual SupplierDto? Supplier { get; set; }
    }
}
