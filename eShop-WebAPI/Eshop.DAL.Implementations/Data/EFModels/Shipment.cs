﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentItems = new HashSet<ShipmentItem>();
        }

        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public int InvoiceNumber { get; set; }
        public string ShipmentTrackingNymber { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public string OtherShipmentDetails { get; set; }

        public virtual Invoice InvoiceNumberNavigation { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
