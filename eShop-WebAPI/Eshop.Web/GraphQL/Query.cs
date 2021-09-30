using System;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Domain.Contracts.IServices;
using HotChocolate;
using HotChocolate.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Web.GraphQL
{
    public class Query
    {
        public IQueryable<Customer> GetCustomers([Service] EshopdbContext context) =>
           context.Customers;
    }
}
