using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Process;

namespace ProcessGateway.Models
{
    public class PaymentTry
    {
        public string Id { get; set; }
        public ProcessState Status { get; set; }
        public int Tries { get; set; }
       
    }
}
