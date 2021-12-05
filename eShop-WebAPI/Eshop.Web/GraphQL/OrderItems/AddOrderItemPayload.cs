using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.OrderItems
{
    public class AddOrderItemPayload : OrderItemPayloadBase
    {
        public AddOrderItemPayload(OrderItem orderItem)
            : base(orderItem)
        {
        }

        public AddOrderItemPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
