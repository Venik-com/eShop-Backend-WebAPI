using System;
using System.Collections.Generic;

#nullable disable

namespace Eshop.Web.Data.EFModels
{
    public partial class Invoice
    {
        public Invoice()
        {
            Payments = new HashSet<Payment>();
            Shipments = new HashSet<Shipment>();
        }

        public Guid InvoiceNumber { get; set; }
        public Guid OrderId { get; set; }
        public string InvoiceStatusCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDetails { get; set; }

        public virtual RefInvoiceStatusCode InvoiceStatusCodeNavigation { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
