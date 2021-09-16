using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class RefPaymentMethod
    {
        public RefPaymentMethod()
        {
            CustomerPaymentMethods = new HashSet<CustomerPaymentMethod>();
        }

        public string PaymentMethodCode { get; set; }
        public string PaymentMethodDescription { get; set; }

        public virtual ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
    }
}
