using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProcessGateway.Models
{
    public class PaymentDetails
    {
        
        public String CreditCardNumber { get;  set; }

        public String CardHolder { get; set; }

        public DateTime ExpirationDate { get; set; }

        public String SecurityCode { get; set; }

        public decimal Amount { get; set; }

    }
}
