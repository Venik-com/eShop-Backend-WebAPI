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
        public IQueryable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
