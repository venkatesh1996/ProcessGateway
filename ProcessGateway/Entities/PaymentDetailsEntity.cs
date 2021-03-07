using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Process;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProcessGateway.Entities
{
    public class PaymentDetailsEntity:StatusStore<String>
    {
        [Required]
        [Column(TypeName = "varchar(20)")]
        public String CreditCardNumber { get; set; }

        [Required]
        [Column(TypeName ="varchar(100)")]
        public String CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public String SecurityCode { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public ProcessState process { get; set; }
        public int Tries { get; set; }
    }
}
