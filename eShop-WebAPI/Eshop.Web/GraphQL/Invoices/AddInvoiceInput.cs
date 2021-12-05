using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public record AddInvoiceInput(Guid orderId, string invoiceStatusCode, string invoiceDetails);
}
