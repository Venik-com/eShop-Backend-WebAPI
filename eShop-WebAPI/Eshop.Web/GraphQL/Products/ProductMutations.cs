using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Products
{
    [ExtendObjectType("Mutation")]
    public class ProductMutations
    {
        [UseEshopDbContext]
        public async Task<AddProductPayload> AddProductAsync(
            AddProductInput input,
            [ScopedService] EshopdbContext context)
        {
            var product = new Product
            {
                ProductId = new Guid(),
                ProductTypeCode = input.ProductTypeCode,
                ReturnMerchandiseAuthorizationNr = input.ReturnMerchandiseAuthorizationNr,
                ProductName = input.ProductName,
                ProductPrice = input.ProductPrice,
                ProductColor = input.ProductColor,
                ProductSize = input.ProductSize,
                ProductDescription = input.ProductDescription,
                OtherProductDetails = input.OtherProductDetails
            };

            context.Products.Add(product);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.Products.Remove(product);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddProductPayload(errors);
            }

            return new AddProductPayload(product);
        }
    }
}

