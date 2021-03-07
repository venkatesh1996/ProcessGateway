using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessGateway.Payment_Gateway.Cheap_Gateway
{
    public interface ICheapGateway
    {
        bool MakePayment();
    }
}
