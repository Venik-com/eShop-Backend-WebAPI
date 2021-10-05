using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.RefProductTypes
{
    public class RefProductTypeType : ObjectType<RefProductType>
    {
        protected override void Configure(IObjectTypeDescriptor<RefProductType> descriptor)
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
