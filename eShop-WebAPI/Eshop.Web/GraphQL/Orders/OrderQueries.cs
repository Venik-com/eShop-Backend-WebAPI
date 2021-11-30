using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.DataLoader;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Orders
{
    [ExtendObjectType("Query")]
    public class OrderQueries
    {
        [UseEshopDbContext]
        public Task<List<Order>> GetOrders([ScopedService] EshopdbContext context) =>
            context.Orders.ToListAsync();

        public async Task<Order> GetOrderByIdAsync(
            [ID(nameof(Order))] Guid id,
            OrderByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Order>> GetOrdersByIdAsync(
            [ID(nameof(Order))] Guid[] ids,
            OrderByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);

        [UseEshopDbContext]
        [UsePaging(IncludeTotalCount = true)]
        public IQueryable<Order> GetOrdersByStatusCode(
            [ScopedService] EshopdbContext context) =>
            context.Orders.OrderBy(t => t.OrderStatusCode);
    }
}
