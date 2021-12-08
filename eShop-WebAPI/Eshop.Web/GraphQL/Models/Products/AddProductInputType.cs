using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Products
{
    public class AddProductInputType : InputObjectType<AddProductInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddProductInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Product.");

            descriptor
                .Field(c => c.ProductTypeCode)
                .Description("Код типа продукта.");
            descriptor
                .Field(c => c.ReturnMerchandiseAuthorizationNr)
                .Description("Дата оплаты.");
            descriptor
                .Field(c => c.ProductName)
                .Description("Название продукта.");
            descriptor
                .Field(c => c.ProductPrice)
                .Description("Цена продукта.");
            descriptor
                .Field(c => c.ProductColor)
                .Description("Цвет продукта.");
            descriptor
                .Field(c => c.ProductSize)
                .Description("Размер продукта.");
            descriptor
                .Field(c => c.ProductDescription)
                .Description("Описание продукта.");
            descriptor
                .Field(c => c.OtherProductDetails)
                .Description("Дополнительная информация о продукте.");

            base.Configure(descriptor);
        }
    }
}
