using System;

namespace Eshop.Web.GraphQL.Orders
{
    public record AddOrderInput(Guid CustomerId, string OrderStatusCode, 
        string DataOrderPlaced, string OrderDetails);
    
}
