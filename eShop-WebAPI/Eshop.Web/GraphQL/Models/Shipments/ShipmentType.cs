using Eshop.Web.Data.EFModels;
using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Shipments
{
    public class ShipmentType : ObjectType<Shipment>
    {
        protected override void Configure(IObjectTypeDescriptor<Shipment> descriptor)
        {
            descriptor.Description("Represents the input to add for a Shipment.");

            descriptor
                .Field(c => c.OrderId)
                .Description("Код типа продукта.");
            descriptor
                .Field(c => c.InvoiceNumber)
                .Description("Дата оплаты.");
            descriptor
                .Field(c => c.ShipmentTrackingNymber)
                .Description("Название продукта.");
            descriptor
                .Field(c => c.ShipmentDate)
                .Description("Цена продукта.");
            descriptor
                .Field(c => c.OtherShipmentDetails)
                .Description("Цвет продукта.");

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
