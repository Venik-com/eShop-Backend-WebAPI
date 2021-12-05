using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    [ExtendObjectType("Mutation")]
    public class InvoiceMutations
    {
        [UseEshopDbContext]
        public async Task<AddInvoicePayload> AddInvoiceAsync(
            AddInvoiceInput input,
            [ScopedService] EshopdbContext context)
        {
            var invoice = new Invoice
            {
                InvoiceNumber = new Guid(),
                OrderId = input.orderId,
                InvoiceStatusCode = input.invoiceStatusCode,
                InvoiceDate = DateTime.Now,
                InvoiceDetails = input.invoiceDetails
            };

            context.Invoices.Add(invoice);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.Invoices.Remove(invoice);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddInvoicePayload(errors);
            }

            return new AddInvoicePayload(invoice);
        }
    }
}
