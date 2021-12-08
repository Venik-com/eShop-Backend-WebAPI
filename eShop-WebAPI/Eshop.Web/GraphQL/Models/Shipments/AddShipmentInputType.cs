using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Shipments
{
    public class AddShipmentInputType : InputObjectType<AddShipmentInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddShipmentInput> descriptor)
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
                .Field(c => c.OtherShipmentDetails)
                .Description("Цвет продукта.");

            base.Configure(descriptor);
        }
    }
}
