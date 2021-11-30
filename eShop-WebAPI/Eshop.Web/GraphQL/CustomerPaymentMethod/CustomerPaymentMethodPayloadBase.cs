using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.CustomerPaymentMethod
{
    public class CustomerPaymentMethodPayloadBase : Payload
    {
        protected CustomerPaymentMethodPayloadBase(Data.EFModels.CustomerPaymentMethod customerPaymentMethod)
        {
            CustomerPaymentMethod = customerPaymentMethod;
        }

        protected CustomerPaymentMethodPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Data.EFModels.CustomerPaymentMethod? CustomerPaymentMethod { get; }
    }
}
