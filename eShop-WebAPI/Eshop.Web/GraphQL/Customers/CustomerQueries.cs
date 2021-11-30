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

namespace Eshop.Web.GraphQL.Customers
{
    [ExtendObjectType("Query")]
    public class CustomerQueries
    {
        [UseEshopDbContext]
        public Task<List<Customer>> GetCustomers([ScopedService] EshopdbContext context) =>
            context.Customers.ToListAsync();

        public Task<Customer> GetCustomerByIdAsync(
            [ID(nameof(Customer))] int id,
            CustomerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Customer>> GetCustomersByIdAsync(
            [ID(nameof(Customer))] int[] ids,
            CustomerByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);

        [UseEshopDbContext]
        [UsePaging(IncludeTotalCount = true)]
        public IQueryable<Customer> GetCustomersOrderByFirstName(
            [ScopedService] EshopdbContext context) =>
            context.Customers.OrderBy(t => t.FirstName);
    }
}
