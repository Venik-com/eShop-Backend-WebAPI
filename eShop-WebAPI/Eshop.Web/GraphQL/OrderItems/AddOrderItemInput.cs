using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.OrderItems
{
    public record AddOrderItemInput(Guid ProductId, Guid OrderId, int OrderItemStatusCode, int OrderItemQuantity, decimal OrderItemPrice,
        int RmaNumber, string RmaIssuedBy, string OtherOrderItemDetails);
}
