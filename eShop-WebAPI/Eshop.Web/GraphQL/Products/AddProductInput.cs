using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Products
{
    public record AddProductInput(string ProductTypeCode, string ReturnMerchandiseAuthorizationNr,
        string ProductName, int? ProductPrice, string ProductColor, string ProductSize, string ProductDescription,
        string OtherProductDetails);
}
