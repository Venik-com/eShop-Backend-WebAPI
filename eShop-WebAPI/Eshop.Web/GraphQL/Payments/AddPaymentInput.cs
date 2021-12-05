using Eshop.Web.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Payments
{
    public record AddPaymentInput(Guid PaymentId, Guid InvoiceNumber, decimal? PaymentAmount);
}
