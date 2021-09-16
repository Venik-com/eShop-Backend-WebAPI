using System;
using Eshop.Web.Data.EFModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Domain.Contracts.IServices
{
    public interface IShipmentService
    {
        IQueryable<Shipment> GetAll();
        IQueryable<Shipment> Get();
    }
}
