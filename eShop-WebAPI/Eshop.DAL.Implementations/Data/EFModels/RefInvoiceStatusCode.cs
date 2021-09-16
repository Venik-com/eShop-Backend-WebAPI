using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class RefInvoiceStatusCode
    {
        public RefInvoiceStatusCode()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string InvoiceStatusCode { get; set; }
        public string InvoiceStatusCodeDescription { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
