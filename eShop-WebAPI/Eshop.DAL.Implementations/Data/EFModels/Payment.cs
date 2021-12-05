using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class Payment
    {
        public Guid PaymentId { get; set; }
        public Guid InvoiceNumber { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }

        public virtual Invoice InvoiceNumberNavigation { get; set; }
    }
}
