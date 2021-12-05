using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.DataLoader;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate.Resolvers;
using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Models.OrderItems
{
    public class OrderItemType : ObjectType<OrderItem>
    {
        protected override void Configure(IObjectTypeDescriptor<OrderItem> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.OrderItemId)
                .ResolveNode((ctx, id) => ctx.DataLoader<OrderItemByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.OrderItemId)
                .UseUpperCase();
        }
    }
}
