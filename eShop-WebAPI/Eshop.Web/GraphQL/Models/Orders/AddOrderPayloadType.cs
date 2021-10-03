using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Orders
{
    public class AddOrderPayloadType : ObjectType<AddOrderPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddOrderPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Order.");

            descriptor
                .Field(c => c.Order)
                .Description("Represents the added invoice.");

            base.Configure(descriptor);
        }
    }
}
