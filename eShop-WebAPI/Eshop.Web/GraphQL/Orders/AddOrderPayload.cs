using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Orders
{
    public class AddOrderPayload : OrderPayloadBase
    {
        public AddOrderPayload(Order order)
            : base(order)
        {
        }

        public AddOrderPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
