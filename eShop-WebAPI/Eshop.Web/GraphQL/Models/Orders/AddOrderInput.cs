using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Orders
{
    public record AddOrderInput(int OrderId, int CustomerId, string OrderStatusCode, string DataOrderPlaced, string OrderDetails);
}
