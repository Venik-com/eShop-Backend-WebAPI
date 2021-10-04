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
    public class InvoiceByInvoiceNumberDataLoader : BatchDataLoader<int, Invoice>
    {
        private readonly IDbContextFactory<EshopdbContext> _dbContextFactory;

        public InvoiceByInvoiceNumberDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<EshopdbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Invoice>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using EshopdbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Invoices
                .Where(s => keys.Contains(s.InvoiceNumber))
                .ToDictionaryAsync(t => t.InvoiceNumber, cancellationToken);
        }
    }
}
