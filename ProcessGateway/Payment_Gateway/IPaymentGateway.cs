using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Payment_Gateway.Cheap_Gateway;
using ProcessGateway.Payment_Gateway.Expensive_Gateway;
using ProcessGateway.Payment_Gateway.Premium_Gateway;
namespace ProcessGateway.Payment_Gateway
{
    public interface IPaymentGateway
    {
        ICheapGateway CheapPayments { get; }
        IExpensiveGateway ExpensivePayments { get; }
        IPremiumGateway PremiumPayments { get; }

    }
}
