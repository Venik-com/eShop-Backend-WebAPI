using System;
using Eshop.Domain.Contracts.IServices;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Implementations.Services
{
    public class InvoiceService : IInvoiceService
    {
        private EshopdbContext _context;

        public InvoiceService(EshopdbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Delete(int InvoiceNumber)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Invoice> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> Update(int InvoiceNumber)
        {
            throw new NotImplementedException();
        }
    }
}
