using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Payments
{
    public class PaymentPayloadBase : Payload
    {
        protected PaymentPayloadBase(Payment payment)
        {
            Payment = payment;
        }

        protected PaymentPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Payment? Payment { get; }
    }
}
