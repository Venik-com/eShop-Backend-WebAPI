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
    public class RefProductTypeByProductTypeCodeDataLoader : BatchDataLoader<string, RefProductType>
    {
        private readonly IDbContextFactory<EshopdbContext> _dbContextFactory;

        public RefProductTypeByProductTypeCodeDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<EshopdbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<string, RefProductType>> LoadBatchAsync(
            IReadOnlyList<string> keys,
            CancellationToken cancellationToken)
        {
            await using EshopdbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.RefProductTypes
                .Where(s => keys.Contains(s.ProductTypeCode))
                .ToDictionaryAsync(t => t.ProductTypeCode, cancellationToken);
        }
    }
}
