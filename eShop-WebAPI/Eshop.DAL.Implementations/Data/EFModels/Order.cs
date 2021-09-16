using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderItems = new HashSet<OrderItem>();
            Shipments = new HashSet<Shipment>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatusCode { get; set; }
        public string DataOrderPlaced { get; set; }
        public string OrderDetails { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RefOrderStatusCode OrderStatusCodeNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
