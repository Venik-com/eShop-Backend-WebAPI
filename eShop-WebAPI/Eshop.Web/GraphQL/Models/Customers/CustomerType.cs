using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.DataLoader;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Customers
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.CustomerId)
                .ResolveNode((ctx, id) => ctx.DataLoader<CustomerByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

            //descriptor
            //    .Field(c => c.Orders)
            //    .ResolveWith<CustomerResolvers>(c => c.GetOrders(default!, default!, default!, default))
            //    .UseDbContext<EshopdbContext>()
            //    .Description("This is the Customer descriptor with 'CustomerResolvers' class.");
            
            descriptor
                .Field(t => t.FirstName)
                .UseUpperCase();
        }

        //private class CustomerResolvers
        //{
        //    public async Task<IEnumerable<Order>> GetOrders(
        //        Customer customer,
        //        [ScopedService] EshopdbContext dbContext,
        //        OrderByIdDataLoader orderById,
        //        CancellationToken cancellationToken)
        //    {
        //        System.Guid[] orderIds = await dbContext.Customers
        //            .Where(s => s.CustomerId == customer.CustomerId)
        //            .Include(s => s.CustomerId)
        //            .SelectMany(s => s.Orders.Select(t => t.OrderId))
        //            .ToArrayAsync();

        //        return await orderById.LoadAsync(orderIds, cancellationToken);
        //    }
        //}
    }
}
