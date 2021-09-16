using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Contracts.IServices
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetAll();
        IQueryable<Customer> Get();
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(int CustomerId);
        Task<Customer> Delete(int CustomerId);
    }
}
