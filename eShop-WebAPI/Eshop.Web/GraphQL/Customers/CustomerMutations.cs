using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Customers
{
    [ExtendObjectType("Mutation")]
    public class CustomerMutations
    {
        [UseEshopDbContext]
        public async Task<AddCustomerPayload> AddCustomerAsync(
            AddCustomerInput input,
            [ScopedService] EshopdbContext context)
        {
            var customer = new Customer
            {
                CustomerId = new Guid(),
                OrganisationOrPerson = input.OrganisationOrPerson,
                OrganisationName = input.OrganisationName,
                Gender = input.Gender,
                Age = input.Age,
                FirstName = input.FirstName,
                MiddleName = input.MiddleName,
                LastName = input.LastName,
                EmailAddress = input.EmailAddress,
                LoginName = input.LoginName,
                LoginPassword = input.LoginPassword,
                PhoneNumber = input.PhoneNumber,
                AddressLine1 = input.AddressLine1,
                AddressLine2 = input.AddressLine2,
                AddressLine3 = input.AddressLine3,
                AddressLine4 = input.AddressLine4,
                TownCity = input.TownCity,
                County = input.County,
                Country = input.Country
            };

            context.Customers.Add(customer);
            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                context.Customers.Remove(customer);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddCustomerPayload(errors);
            }
            
            return new AddCustomerPayload(customer);
        }
    }
}
