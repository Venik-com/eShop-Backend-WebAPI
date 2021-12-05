using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Payments
{
    public class AddPaymentPayload : PaymentPayloadBase
    {
        public AddPaymentPayload(Payment payment)
            : base(payment)
        {
        }

        public AddPaymentPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
