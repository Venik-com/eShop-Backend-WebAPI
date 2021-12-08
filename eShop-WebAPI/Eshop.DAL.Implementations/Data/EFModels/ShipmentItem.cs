using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class ShipmentItem
    {
        public Guid ShipmentId { get; set; }
        public Guid OrderItemId { get; set; }

        public virtual OrderItem OrderItem { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
