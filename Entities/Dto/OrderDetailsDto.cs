using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderDetailsDto
    {
        public OrderDetailsDto()
        {
            OrderLines = new HashSet<OrderLinesDto>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string? CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string? Comments { get; set; }
        public string? DeliveryInstructions { get; set; }
        public string? InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }

        public string ContactPerson { get; set; } = null;
        public string PickedByPerson { get; set; }
        public string SalespersonPerson { get; set; } = null!;
        public virtual ICollection<OrderLinesDto> OrderLines { get; set; }
    }
}
