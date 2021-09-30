using Eshop.Domain.Contracts.IServices;
using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Implementations.Services
{
    public class CustomerService : ICustomerService
    {
        //private EshopdbContext _context;

        //public CustomerService(EshopdbContext context)
        //{
        //    _context = context;
        //}

        public async Task<Customer> Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Delete(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Customer>> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> GetAll()
        {
            return null;// _context.Customers.AsQueryable();
        }

        public async Task<Customer> Update(int CustomerId)
        {
            throw new NotImplementedException();
        }
    }
}
