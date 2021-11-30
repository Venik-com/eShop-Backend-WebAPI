using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Orders
{
    public class OrderPayloadBase : Payload
    {
        protected OrderPayloadBase(Order order)
        {
            Order = order;
        }

        protected OrderPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Order? Order { get; }
    }
}
