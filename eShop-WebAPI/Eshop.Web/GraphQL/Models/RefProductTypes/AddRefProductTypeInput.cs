using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.RefProductTypes
{
    public record AddRefProductTypeInput(string ProductTypeCode, string ParentProductTypeCode, string ProductTypeDescription);
}
