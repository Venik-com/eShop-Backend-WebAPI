using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.CustomerPaymentMethod
{
    [ExtendObjectType("Mutation")]
    public class CustomerPaymentMethodMutations
    {
        [UseEshopDbContext]
        public async Task<AddCustomerPaymentMethodPayload> AddCustomerPaymentMethodAsync(
            AddCustomerPaymentMethodInput input,
            [ScopedService] EshopdbContext context)
        {
            var customerPaymentMethod = new Data.EFModels.CustomerPaymentMethod
            {
                CustomerPaymentId = new Guid(),
                CustomerId = input.CustomerId,
                PaymentMethodCode = input.PaymentMethodCode,
                CreditCardNumber = input.CreditCardNumber,
                PaymentMethodDetails = input.PaymentMethodDetails
            };

            context.CustomerPaymentMethods.Add(customerPaymentMethod);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.CustomerPaymentMethods.Remove(customerPaymentMethod);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddCustomerPaymentMethodPayload(errors);
            }

            return new AddCustomerPaymentMethodPayload(customerPaymentMethod);
        }
    }
}
