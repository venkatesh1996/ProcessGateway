using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Payment_Gateway.Cheap_Gateway;
using ProcessGateway.Payment_Gateway.Expensive_Gateway;
using ProcessGateway.Payment_Gateway.Premium_Gateway;

namespace ProcessGateway.Payment_Gateway
{
    public class PaymentGateway:IPaymentGateway
    {
        public PaymentGateway()
        {
            CheapPayments = new CheapGateway();
            ExpensivePayments = new ExpensiveGateway();
            PremiumPayments = new PremiumGateway();
        }
        public ICheapGateway CheapPayments { get; private set; }

        

        public IExpensiveGateway ExpensivePayments { get; private set; }

       

        public IPremiumGateway PremiumPayments { get; private set; }

        
    }
}
