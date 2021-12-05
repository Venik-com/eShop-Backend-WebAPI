using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.OrderItems
{
    public class OrderItemPayloadBase : Payload
    {
        protected OrderItemPayloadBase(OrderItem orderItem)
        {
            OrderItem = orderItem;
        }

        protected OrderItemPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public OrderItem? OrderItem { get; }
    }
}
