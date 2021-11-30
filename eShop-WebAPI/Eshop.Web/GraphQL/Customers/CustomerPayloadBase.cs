using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
