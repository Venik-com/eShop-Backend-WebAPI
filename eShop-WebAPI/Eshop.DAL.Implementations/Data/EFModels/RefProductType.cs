using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class RefProductType
    {
        public RefProductType()
        {
            InverseParentProductTypeCodeNavigation = new HashSet<RefProductType>();
            Products = new HashSet<Product>();
        }

        public string ProductTypeCode { get; set; }
        public string ParentProductTypeCode { get; set; }
        public string ProductTypeDescription { get; set; }

        public virtual RefProductType ParentProductTypeCodeNavigation { get; set; }
        public virtual ICollection<RefProductType> InverseParentProductTypeCodeNavigation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
