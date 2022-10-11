using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class StockItemsDto
    {
        public int StockItemId { get; set; }
        public string StockItemName { get; set; } = null!;
        public int SupplierId { get; set; }
        public string? Brand { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public string? MarketingComments { get; set; }
        public byte[]? Photo { get; set; }
        public string? Tags { get; set; }
    }
}
