﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class CustomerPaymentMethod
    {
        public int CustomerPaymentId { get; set; }
        public int CustomerId { get; set; }
        public string PaymentMethodCode { get; set; }
        public string CreditCardNumber { get; set; }
        public string PaymentMethodDetails { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual RefPaymentMethod PaymentMethodCodeNavigation { get; set; }
    }
}
