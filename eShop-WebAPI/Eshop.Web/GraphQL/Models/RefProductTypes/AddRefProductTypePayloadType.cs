using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.RefProductTypes
{
    public class AddRefProductTypePayloadType : ObjectType<AddRefProductTypePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddRefProductTypePayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Shipment.");

            descriptor
                .Field(c => c.RefProductType)
                .Description("Represents the added RefProductType.");

            base.Configure(descriptor);
        }
    }
}
