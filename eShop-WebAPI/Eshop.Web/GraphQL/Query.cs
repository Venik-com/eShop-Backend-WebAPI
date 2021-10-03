using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Eshop.Web.GraphQL.Extensions;
using System.Threading;
using Eshop.Web.GraphQL.DataLoader;

namespace Eshop.Web.GraphQL
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Customer>> GetCustomers([ScopedService] EshopdbContext context) =>
           context.Customers.ToListAsync();

        public Task<Customer> GetCustomerAsync(
                int id,
                CustomerByIdDataLoader dataLoader,
                CancellationToken cancellationToken) =>
                dataLoader.LoadAsync(id, cancellationToken);


        [UseApplicationDbContext]
        public Task<List<Invoice>> GetInvoices([ScopedService] EshopdbContext context) =>
           context.Invoices.ToListAsync();

        public Task<Invoice> GetInvoiceAsync(
                int id,
                InvoiceByIdDataLoader dataLoader,
                CancellationToken cancellationToken) =>
                dataLoader.LoadAsync(id, cancellationToken);
    }
}
