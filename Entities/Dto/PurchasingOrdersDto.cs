using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class PurchasingOrdersDto
    {
        public PurchasingOrdersDto()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLineDto>();
        }

        public int PurchaseOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ContactPersonId { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? Comments { get; set; }

        public string DeliveryMethodName { get; set; }
        public string ContactPersonName { get; set; }

        public virtual ICollection<PurchaseOrderLineDto> PurchaseOrderLines { get; set; }
    }
}
