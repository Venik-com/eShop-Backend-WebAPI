using Eshop.Web.Data.EFModels;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.DataLoader
{
    public class OrderByIdDataLoader : BatchDataLoader<int, Order>
    {
        private readonly IDbContextFactory<EshopdbContext> _dbContextFactory;

        public OrderByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<EshopdbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Order>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using EshopdbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Orders
                .Where(s => keys.Contains(s.OrderId))
                .ToDictionaryAsync(t => t.OrderId, cancellationToken);
        }
    }
}
