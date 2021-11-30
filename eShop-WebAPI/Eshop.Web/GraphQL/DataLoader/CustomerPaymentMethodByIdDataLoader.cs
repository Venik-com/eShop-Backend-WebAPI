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
    public class CustomerPaymentMethodByIdDataLoader : BatchDataLoader<Guid, Data.EFModels.CustomerPaymentMethod>
    {
        private readonly IDbContextFactory<EshopdbContext> _dbContextFactory;

        public CustomerPaymentMethodByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<EshopdbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Data.EFModels.CustomerPaymentMethod>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            await using EshopdbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.CustomerPaymentMethods
                .Where(s => keys.Contains(s.CustomerPaymentId))
                .ToDictionaryAsync(t => t.CustomerPaymentId, cancellationToken);
        }
    }
}
