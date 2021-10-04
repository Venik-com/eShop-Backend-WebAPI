using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Payments
{
    public class PaymentType : ObjectType<Payment>
    {
        protected override void Configure(IObjectTypeDescriptor<Payment> descriptor)
        {
            descriptor.Description("Represents the input to add for a Payment.");

            descriptor
                .Field(c => c.PaymentId)
                .Description("Номер платежа.");
            descriptor
                .Field(c => c.InvoiceNumber)
                .Description("Id счет-фактуры.");
            descriptor
                .Field(c => c.PaymentDate)
                .Description("Дата оплаты.");
            descriptor
                .Field(c => c.PaymentAmount)
                .Description("Сумма оплаты.");

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
