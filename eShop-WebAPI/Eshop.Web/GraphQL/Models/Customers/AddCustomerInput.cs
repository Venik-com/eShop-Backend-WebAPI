using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Customers
{
    public record AddCustomerInput(string OrganisationOrPerson, string OrganisationName, string MiddleName,string PhoneNumber,
        string Gender, int? Age, string AddressLine1, string AddressLine2, string AddressLine3,
        string AddressLine4, string TownCity, string County, string Country,
        string FirstName, string LastName, string EmailAddress, string LoginName, string LoginPassword);
}
