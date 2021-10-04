using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Products
{
    public class AddProductPayloadType : ObjectType<AddProductPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddProductPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Product.");

            descriptor
                .Field(c => c.Product)
                .Description("Represents the added Product.");

            base.Configure(descriptor);
        }
    }
}
