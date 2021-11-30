using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Customers
{
    public class AddCustomerPayload : CustomerPayloadBase
    {
        public AddCustomerPayload(Customer customer)
            : base(customer)
        {
        }

        public AddCustomerPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
