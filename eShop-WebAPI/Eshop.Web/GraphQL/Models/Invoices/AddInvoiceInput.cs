using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public record AddInvoiceInput(int InvoiceNumber, int OrderId, string InvoiceStatusCode, DateTime? InvoiceDate, string InvoiceDetails);
}
