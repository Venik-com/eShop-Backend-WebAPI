using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Customers
{
    public class AddCustomerPayloadType : ObjectType<AddCustomerPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddCustomerPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added customer.");

            descriptor
                .Field(c => c.Customer)
                .Description("Represents the added customer.");

            base.Configure(descriptor);
        }
    }
}
