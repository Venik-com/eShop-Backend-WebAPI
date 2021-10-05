using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Shipments
{
    public record AddShipmentInput(int ShipmentId, int OrderId, int InvoiceNumber, string ShipmentTrackingNymber,
        DateTime? ShipmentDate, string OtherShipmentDetails);
}
