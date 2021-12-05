using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Invoices
{
    public class AddInvoiceInputType : InputObjectType<AddInvoiceInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddInvoiceInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a customer.");

            //descriptor
            //    .Field(c => c.InvoiceNumber)
            //    .Description("Номер счет-фактуры.");
            //descriptor
            //    .Field(c => c.OrderId)
            //    .Description("Id заказа.");
            //descriptor
            //    .Field(c => c.InvoiceStatusCode)
            //    .Description("Код статуса счет-фактуры.");
            //descriptor
            //    .Field(c => c.InvoiceDate)
            //    .Description("Дата создания счет-фактуры.");
            //descriptor
            //    .Field(c => c.InvoiceDetails)
            //    .Description("Дополнительная информация о счет-фактуре.");

            base.Configure(descriptor);
        }
    }
}
