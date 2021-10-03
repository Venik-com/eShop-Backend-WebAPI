using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Orders
{
    public class AddOrderInputType : InputObjectType<AddOrderInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddOrderInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a customer.");

            descriptor
                .Field(c => c.OrderId)
                .Description("Номер счет-фактуры.");
            descriptor
                .Field(c => c.CustomerId)
                .Description("Id заказа.");
            descriptor
                .Field(c => c.OrderStatusCode)
                .Description("Код статуса счет-фактуры.");
            descriptor
                .Field(c => c.DataOrderPlaced)
                .Description("Дата создания счет-фактуры.");
            descriptor
                .Field(c => c.OrderDetails)
                .Description("Дополнительная информация о счет-фактуре.");

            base.Configure(descriptor);
        }
    }
}
