using Eshop.Web.GraphQL.OrderItems;
using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Models.OrderItems
{
    public class AddCustomerPayloadType : ObjectType<AddOrderItemPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddOrderItemPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added OrderItem.");

            descriptor
                .Field(c => c.OrderItem)
                .Description("Represents the added OrderItem.");

            base.Configure(descriptor);
        }
    }
}
