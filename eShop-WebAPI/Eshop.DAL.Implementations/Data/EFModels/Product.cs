using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProductId { get; set; }
        public string ProductTypeCode { get; set; }
        public string ReturnMerchandiseAuthorizationNr { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string ProductDescription { get; set; }
        public string OtherProductDetails { get; set; }

        public virtual RefProductType ProductTypeCodeNavigation { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
