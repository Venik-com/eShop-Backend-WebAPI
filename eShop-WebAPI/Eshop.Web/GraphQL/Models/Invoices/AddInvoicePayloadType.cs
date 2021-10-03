using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public class AddOrderPayloadType : ObjectType<AddInvoicePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddInvoicePayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added customer.");

            descriptor
                .Field(c => c.Invoice)
                .Description("Represents the added invoice.");

            base.Configure(descriptor);
        }
    }
}
