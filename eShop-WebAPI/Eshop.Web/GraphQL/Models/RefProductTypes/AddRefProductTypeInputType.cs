using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.RefProductTypes
{
    public class AddRefProductTypeInputType : InputObjectType<AddRefProductTypeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddRefProductTypeInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a RefProductType.");

            descriptor
                .Field(c => c.ProductTypeCode)
                .Description("Id продукта.");
            descriptor
                .Field(c => c.ParentProductTypeCode)
                .Description("Код типа продукта.");
            descriptor
                .Field(c => c.ProductTypeDescription)
                .Description("Дата оплаты.");

            base.Configure(descriptor);
        }
    }
}
