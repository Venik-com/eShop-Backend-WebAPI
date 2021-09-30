using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
