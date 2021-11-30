using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.CustomerPaymentMethod
{
    public record AddCustomerPaymentMethodInput(Guid customerId, string paymentMethodCode, string creditCardNumber, 
        string paymentMethodDetails);
}
