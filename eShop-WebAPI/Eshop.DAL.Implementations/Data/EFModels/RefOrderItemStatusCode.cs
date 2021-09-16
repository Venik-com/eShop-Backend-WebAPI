using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class RefOrderItemStatusCode
    {
        public RefOrderItemStatusCode()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderItemStatusCode { get; set; }
        public string OrderItemStatusCodeDescription { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
