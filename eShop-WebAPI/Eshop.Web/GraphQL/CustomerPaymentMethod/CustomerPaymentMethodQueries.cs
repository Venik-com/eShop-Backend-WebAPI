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

namespace Eshop.Web.GraphQL.CustomerPaymentMethod
{
    [ExtendObjectType("Query")]
    public class CustomerPaymentMethodQueries
    {
        [UseEshopDbContext]
        public Task<List<Data.EFModels.CustomerPaymentMethod>> GetCustomerPaymentMethods([ScopedService] EshopdbContext context) =>
            context.CustomerPaymentMethods.ToListAsync();

        public async Task<Data.EFModels.CustomerPaymentMethod> GetCustomerPaymentMethodByIdAsync(
            [ID(nameof(CustomerPaymentMethod))] Guid id,
            CustomerPaymentMethodByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Data.EFModels.CustomerPaymentMethod>> GetCustomerPaymentMethodsByIdAsync(
            [ID(nameof(CustomerPaymentMethod))] Guid[] ids,
            CustomerPaymentMethodByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
