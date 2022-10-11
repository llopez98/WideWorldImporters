using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class SupplierTransactionsDto
    {
        public int SupplierTransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime? FinalizationDate { get; set; }

        public string PaymentMethod { get; set; }
        public string TransactionType { get; set; } = null!;
    }
}
