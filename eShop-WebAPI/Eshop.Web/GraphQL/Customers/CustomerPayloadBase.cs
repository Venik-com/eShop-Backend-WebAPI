using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Customers
{
    public class CustomerPayloadBase : Payload
    {
        protected CustomerPayloadBase(Customer customer)
        {
            Customer = customer;
        }

        protected CustomerPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Customer? Customer { get; }
    }
}
