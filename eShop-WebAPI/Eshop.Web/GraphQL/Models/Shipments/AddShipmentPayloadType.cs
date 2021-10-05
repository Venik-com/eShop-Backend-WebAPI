using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
