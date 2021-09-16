using System;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Contracts.IServices
{
    public interface IOrderService
    {
        IQueryable<Order> GetAll();
        IQueryable<Order> Get();
        Task<Order> Create(Order customer);
        Task<Order> Update(int OrderId);
        Task<Order> Delete(int OrderId);
    }
}
