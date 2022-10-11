using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string? SupplierCategoryName { get; set; }
        public string? PrimaryContact { get; set; }
        public string? AlternateContact { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string FaxNumber { get; set; } = null!;
        public string WebsiteUrl { get; set; } = null!;
        public string? DeliveryMethod { get; set; }
        public string? CityName { get; set; }
    }
}
