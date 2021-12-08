using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Products
{
    public class ProductPayloadBase : Payload
    {
        protected ProductPayloadBase(Product product)
        {
            Product = product;
        }

        protected ProductPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Product? Product { get; }
    }
}
