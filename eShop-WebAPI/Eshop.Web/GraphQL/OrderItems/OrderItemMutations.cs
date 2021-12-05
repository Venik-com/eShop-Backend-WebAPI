using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.OrderItems
{
    [ExtendObjectType("Mutation")]
    public class OrderItemMutations
    {
        [UseEshopDbContext]
        public async Task<AddOrderItemPayload> AddOrderItemAsync(
            AddOrderItemInput input,
            [ScopedService] EshopdbContext context)
        {
            var orderItem = new OrderItem
            {
                OrderItemId = new Guid(),
                ProductId = input.ProductId,
                OrderId = input.OrderId,
                OrderItemStatusCode = input.OrderItemStatusCode,
                OrderItemQuantity = input.OrderItemQuantity,
                OrderItemPrice = input.OrderItemPrice,
                RmaNumber = input.RmaNumber,
                RmaIssuedBy = input.RmaIssuedBy,
                RmaIssuedDate = DateTime.Now,
                OtherOrderItemDetails = input.OtherOrderItemDetails
            };

            context.OrderItems.Add(orderItem);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.OrderItems.Remove(orderItem);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddOrderItemPayload(errors);
            }

            return new AddOrderItemPayload(orderItem);
        }
    }
}
