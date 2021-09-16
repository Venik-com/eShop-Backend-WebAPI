using System;
using Eshop.Domain.Contracts.IServices;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Implementations.Services
{
    public class ProductService : IProductService
    {
        private EshopdbContext _context;

        public ProductService(EshopdbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(int ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
