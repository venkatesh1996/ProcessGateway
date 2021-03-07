using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Payment_Gateway.Premium_Gateway
{
    public class PremiumGateway:IPremiumGateway
    {
        public bool MakePayment() => (new Random().Next(0, 1)) == 1;
    }
}
