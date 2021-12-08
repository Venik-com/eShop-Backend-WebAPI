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

namespace Eshop.Web.GraphQL.Products
{
    [ExtendObjectType("Query")]
    public class ProductQueries
    {
        [UseEshopDbContext]
        public Task<List<Product>> GetProducts([ScopedService] EshopdbContext context) =>
            context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(
            [ID(nameof(Product))] Guid id,
            ProductByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Product>> GetProductsByIdAsync(
            [ID(nameof(Product))] Guid[] ids,
            ProductByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);

        [UseEshopDbContext]
        [UsePaging(IncludeTotalCount = true)]
        public IQueryable<Product> GetProductsOrderByName(
            [ScopedService] EshopdbContext context) =>
            context.Products.OrderBy(t => t.ProductName);
    }
}
