using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.CustomerPaymentMethod
{
    public class AddCustomerPaymentMethodPayload : CustomerPaymentMethodPayloadBase
    {
        public AddCustomerPaymentMethodPayload(Data.EFModels.CustomerPaymentMethod сustomerPaymentMethod)
            : base(сustomerPaymentMethod)
        {
        }

        public AddCustomerPaymentMethodPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
