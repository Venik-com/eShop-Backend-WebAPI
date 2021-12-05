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

namespace Eshop.Web.GraphQL.OrderItems
{
    [ExtendObjectType("Query")]
    public class OrderItemQueries
    {
        [UseEshopDbContext]
        public Task<List<OrderItem>> GetOrderItems([ScopedService] EshopdbContext context) =>
            context.OrderItems.ToListAsync();

        public async Task<OrderItem> GetOrderItemByIdAsync(
            [ID(nameof(OrderItem))] Guid id,
            OrderItemByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByIdAsync(
            [ID(nameof(OrderItem))] Guid[] ids,
            OrderItemByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
