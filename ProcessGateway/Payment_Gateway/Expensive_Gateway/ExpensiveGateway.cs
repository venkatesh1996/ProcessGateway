using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Payment_Gateway.Expensive_Gateway
{
    public class ExpensiveGateway : IExpensiveGateway
    {
        public bool MakePayment() => (new Random().Next(0, 1)) == 1;
        public bool CheckAvailability() => (new Random().Next(0, 1)) == 1;
    }
}