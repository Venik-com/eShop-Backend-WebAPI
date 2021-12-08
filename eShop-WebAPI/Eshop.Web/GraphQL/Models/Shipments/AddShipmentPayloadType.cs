using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Shipments
{
    public class AddShipmentPayloadType : ObjectType<AddShipmentPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddShipmentPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Shipment.");

            descriptor
                .Field(c => c.Shipment)
                .Description("Represents the added Shipment.");

            base.Configure(descriptor);
        }
    }
}
