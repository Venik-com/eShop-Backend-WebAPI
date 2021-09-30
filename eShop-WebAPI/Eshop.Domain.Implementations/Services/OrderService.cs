using System;
using Eshop.Domain.Contracts.IServices;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Implementations.Services
{
    public class OrderService : IOrderService
    {
        //private EshopdbContext _context;

        //public OrderService(EshopdbContext context)
        //{
        //    _context = context;
        //}

        public async Task<Order> Create(Order customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Delete(int OrderId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Order> Update(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
