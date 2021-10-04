using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Payments
{
    public class AddPaymentPayloadType : ObjectType<AddPaymentPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddPaymentPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Order.");

            descriptor
                .Field(c => c.Payment)
                .Description("Represents the added Payment.");

            base.Configure(descriptor);
        }
    }
}
