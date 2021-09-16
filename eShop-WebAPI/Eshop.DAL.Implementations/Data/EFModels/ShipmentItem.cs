using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class ShipmentItem
    {
        public int ShipmentId { get; set; }
        public int OrderItemId { get; set; }

        public virtual OrderItem OrderItem { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
