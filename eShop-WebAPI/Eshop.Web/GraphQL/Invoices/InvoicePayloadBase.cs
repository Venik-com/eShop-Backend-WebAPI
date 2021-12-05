using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Invoices
{
    public class InvoicePayloadBase : Payload
    {
        protected InvoicePayloadBase(Invoice invoice)
        {
            Invoice = invoice;
        }

        protected InvoicePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Invoice? Invoice { get; }
    }
}
