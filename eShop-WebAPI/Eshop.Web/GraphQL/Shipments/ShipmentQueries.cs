using Eshop.Web.Data.EFModels;
using Eshop.Web.GraphQL.DataLoader;
using Eshop.Web.GraphQL.Extensions;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Shipments
{
    [ExtendObjectType("Query")]
    public class ShipmentQueries
    {
        [UseEshopDbContext]
        public Task<List<Shipment>> GetShipments([ScopedService] EshopdbContext context) =>
            context.Shipments.ToListAsync();

        public async Task<Shipment> GetShipmentByIdAsync(
            [ID(nameof(Shipment))] Guid id,
            ShipmentByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Shipment>> GetShipmentsByIdAsync(
            [ID(nameof(Shipment))] Guid[] ids,
            ShipmentByIdDataLoader dataLoader,
            CancellationToken cancellationToken) =>
            await dataLoader.LoadAsync(ids, cancellationToken);
    }
}
