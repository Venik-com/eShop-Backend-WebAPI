﻿using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Customers;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL
{
    public class Mutation
    {
        public async Task<AddCustomerPayload> AddCustomerAsync(
            AddCustomerInput input,
            [Service] EshopdbContext context)
        {
            var customer = new Customer
            {
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
                Debug.WriteLine(e.Message);
            }

            return new AddCustomerPayload(customer);
        }
    }
}