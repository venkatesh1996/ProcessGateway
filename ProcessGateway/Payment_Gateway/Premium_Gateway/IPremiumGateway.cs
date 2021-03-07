using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Payment_Gateway.Premium_Gateway
{
    public  interface IPremiumGateway
    {
         bool MakePayment();
    }
}
