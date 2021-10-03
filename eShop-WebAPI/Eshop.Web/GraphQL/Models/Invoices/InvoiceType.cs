using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public class InvoiceType : ObjectType<Invoice>
    {
        protected override void Configure(IObjectTypeDescriptor<Invoice> descriptor)
        {
            descriptor.Description("Represents any executable invoice.");

            descriptor
                .Field(c => c.InvoiceNumber)
                .Description("Номер счет-фактуры.");
            descriptor
                .Field(c => c.OrderId)
                .Description("Id заказа.");
            descriptor
                .Field(c => c.InvoiceStatusCode)
                .Description("Код статуса счет-фактуры.");
            descriptor
                .Field(c => c.InvoiceDate)
                .Description("Дата создания счет-фактуры.");
            descriptor
                .Field(c => c.InvoiceDetails)
                .Description("Дополнительная информация о счет-фактуре.");

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
