using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Payments
{
    public class AddPaymentInputType : InputObjectType<AddPaymentInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddPaymentInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Payment.");

            descriptor
                .Field(c => c.PaymentId)
                .Description("Номер платежа.");
            descriptor
                .Field(c => c.InvoiceNumber)
                .Description("Id счет-фактуры.");
            descriptor
                .Field(c => c.PaymentAmount)
                .Description("Сумма оплаты.");

            base.Configure(descriptor);
        }
    }
}
