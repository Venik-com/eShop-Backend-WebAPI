using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using System.Collections.Generic;

namespace Eshop.Web.GraphQL.Shipments
{
    public class ShipmentPayloadBase : Payload
    {
        protected ShipmentPayloadBase(Shipment shipment)
        {
            Shipment = shipment;
        }

        protected ShipmentPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Shipment? Shipment { get; }
    }
}
