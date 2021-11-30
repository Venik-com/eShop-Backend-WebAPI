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
    public class CustomerByIdDataLoader : BatchDataLoader<Guid, Customer>
    {
        private readonly IDbContextFactory<EshopdbContext> _dbContextFactory;

        public CustomerByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<EshopdbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Customer>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            await using EshopdbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Customers
                .Where(s => keys.Contains(s.CustomerId))
                .ToDictionaryAsync(t => t.CustomerId, cancellationToken);
        }
    }
}
