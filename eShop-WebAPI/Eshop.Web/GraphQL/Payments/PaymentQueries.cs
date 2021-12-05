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

namespace Eshop.Web.GraphQL.Payments
{
    [ExtendObjectType("Query")]
    public class PaymentQueries
    {
        [UseEshopDbContext]
        public Task<List<Payment>> GetPayments([ScopedService] EshopdbContext context) =>
            context.Payments.ToListAsync();

        public async Task<Payment> GetPaymentByIdAsync(
            [ID(nameof(Payment))] Guid id,
            PaymentByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Payment>> GetPaymentsByIdAsync(
            [ID(nameof(Payment))] Guid[] ids,
            PaymentByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
