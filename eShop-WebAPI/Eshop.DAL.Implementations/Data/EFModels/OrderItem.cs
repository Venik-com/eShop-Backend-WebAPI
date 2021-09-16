using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            ShipmentItems = new HashSet<ShipmentItem>();
        }

        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int OrderItemStatusCode { get; set; }
        public int OrderItemQuantity { get; set; }
        public decimal OrderItemPrice { get; set; }
        public int RmaNumber { get; set; }
        public string RmaIssuedBy { get; set; }
        public DateTime RmaIssuedDate { get; set; }
        public string OtherOrderItemDetails { get; set; }

        public virtual Order Order { get; set; }
        public virtual RefOrderItemStatusCode OrderItemStatusCodeNavigation { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }
}
