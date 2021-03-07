using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Payment_Gateway.Expensive_Gateway
{
    public interface IExpensiveGateway
    {
         bool MakePayment();
         bool CheckAvailability();
    }
}
