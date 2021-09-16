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
        public IQueryable<Invoice> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
