using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Products
{
    public class AddProductPayload : ProductPayloadBase
    {
        public AddProductPayload(Product Product)
            : base(Product)
        {
        }

        public AddProductPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
