using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class CustomersDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerCategoryName { get; set; }
        public string? BuyingGroupName { get; set; }
        public string? CityName { get; set; }
    }
}
