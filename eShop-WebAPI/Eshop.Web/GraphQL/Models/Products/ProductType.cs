using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Products
{
    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.Description("Represents the input to add for a Product.");

            descriptor
                .Field(c => c.ProductId)
                .Description("Id продукта.");
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

            //descriptor
            //    .Field(c => c.Platform)
            //    .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
            //    .UseDbContext<AppDbContext>()
            //    .Description("This is the platform to which the command belongs.");

        }

        //private class Resolvers
        //{
        //    public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
        //    {
        //        return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        //    }
        //}
    }
}
