using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.Common;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Shipments
{
    [ExtendObjectType("Mutation")]
    public class ShipmentMutations
    {
        [UseEshopDbContext]
        public async Task<AddShipmentPayload> AddShipmentAsync(
            AddShipmentInput input,
            [ScopedService] EshopdbContext context)
        {
            var shipment = new Shipment
            {
                ShipmentId = new Guid(),
                OrderId = input.OrderId,
                InvoiceNumber = input.InvoiceNumber,
                ShipmentTrackingNymber = input.ShipmentTrackingNymber,
                ShipmentDate =  DateTime.Now,
                OtherShipmentDetails = input.OtherShipmentDetails
            };

            context.Shipments.Add(shipment);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                context.Shipments.Remove(shipment);

                // В случае ошибки, вернем их список.
                var errors = new List<UserError>();
                errors.Append(new UserError(e.Message, e.HResult.ToString()));
                return new AddShipmentPayload(errors);
            }

            return new AddShipmentPayload(shipment);
        }
    }
}
