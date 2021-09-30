using System;
using Eshop.Domain.Contracts.IServices;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Implementations.Services
{
    public class ShipmentService : IShipmentService
    {
        //private EshopdbContext _context;

        //public ShipmentService(EshopdbContext context)
        //{
        //    _context = context;
        //}

        public async Task<Shipment> Create(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public async Task<Shipment> Delete(int ShipmentId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shipment> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Shipment> Update(int ShipmentId)
        {
            throw new NotImplementedException();
        }
    }
}
