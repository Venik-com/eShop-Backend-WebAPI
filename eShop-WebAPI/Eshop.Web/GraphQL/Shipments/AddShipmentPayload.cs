using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Shipments
{
    public class AddShipmentPayload : ShipmentPayloadBase
    {
        public AddShipmentPayload(Shipment shipment)
            : base(shipment)
        {
        }

        public AddShipmentPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
