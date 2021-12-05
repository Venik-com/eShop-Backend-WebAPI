using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public class AddInvoicePayload : InvoicePayloadBase
    {
        public AddInvoicePayload(Invoice invoice)
            : base(invoice)
        {
        }

        public AddInvoicePayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
