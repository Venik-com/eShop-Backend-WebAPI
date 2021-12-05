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

namespace Eshop.Web.GraphQL.Invoices
{
    [ExtendObjectType("Query")]
    public class InvoiceQueries
    {
        [UseEshopDbContext]
        public Task<List<Invoice>> GetInvoices([ScopedService] EshopdbContext context) =>
            context.Invoices.ToListAsync();

        public async Task<Invoice> GetInvoiceByIdAsync(
            [ID(nameof(Invoice))] Guid id,
            InvoiceByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Invoice>> GetInvoicesByIdAsync(
            [ID(nameof(Invoice))] Guid[] ids,
            InvoiceByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
