using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class RefOrderStatusCode
    {
        public RefOrderStatusCode()
        {
            Orders = new HashSet<Order>();
        }

        public string OrderStatusCode { get; set; }
        public string OrderStatusDescription { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
