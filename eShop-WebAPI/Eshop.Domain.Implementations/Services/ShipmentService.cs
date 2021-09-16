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
        public IQueryable<Shipment> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shipment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
