using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Shipments
{
    public record AddShipmentInput(Guid OrderId, Guid InvoiceNumber, string ShipmentTrackingNymber,
        string OtherShipmentDetails);
}
