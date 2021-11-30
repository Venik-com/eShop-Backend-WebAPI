using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Orders
{
    [ExtendObjectType("Mutation")]
    public class OrderMutations
    {
        [UseEshopDbContext]
        public async Task<AddOrderPayload> AddOrderAsync(
            AddOrderInput input,
            [ScopedService] EshopdbContext context)
        {
            var order = new Order
            {
                OrderId = new Guid(),
                CustomerId = input.CustomerId,
                OrderStatusCode = input.OrderStatusCode,
                DataOrderPlaced = input.DataOrderPlaced,
                OrderDetails = input.OrderDetails
            };

            context.Orders.Add(order);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.Orders.Remove(order);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddOrderPayload(errors);
            }

            return new AddOrderPayload(order);
        }
    }
}
