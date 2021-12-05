using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Payments
{
    [ExtendObjectType("Mutation")]
    public class PaymentMutations
    {
        [UseEshopDbContext]
        public async Task<AddPaymentPayload> AddPaymentAsync(
            AddPaymentInput input,
            [ScopedService] EshopdbContext context)
        {
            var payment = new Payment
            {
                PaymentId = new Guid(),
                InvoiceNumber = input.InvoiceNumber,
                PaymentDate = DateTime.Now,
                PaymentAmount = input.PaymentAmount
            };

            context.Payments.Add(payment);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.Payments.Remove(payment);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddPaymentPayload(errors);
            }

            return new AddPaymentPayload(payment);
        }
    }
}
