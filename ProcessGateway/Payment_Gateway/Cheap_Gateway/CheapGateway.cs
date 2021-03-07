using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Models;

namespace ProcessGateway.Payment_Gateway.Cheap_Gateway
{
    public class CheapGateway:ICheapGateway
    {
        
       public bool MakePayment() => (new Random().Next(0, 1)) == 1;
    }
}
