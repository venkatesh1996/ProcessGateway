using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessGateway.Models;
using ProcessGateway.Validators;
using FluentAssertions;
using FluentValidation.Results;


namespace ProcessGateway.Unit_Tests
{
    public class ProcessPayments
    {
       
        public void ProcessPayments_Validator_Invalid(decimal amount, string cardHolder, string creditCard, DateTime exp, string sec)
        {
            // Arrange
            PaymentDetails model = new PaymentDetails()
            {
                Amount = amount,
                CardHolder = cardHolder,
                CreditCardNumber = creditCard,
                ExpirationDate = exp,
                SecurityCode = sec
            };

            // Act
            PaymentDetailsValidator _validator = new PaymentDetailsValidator();
            ValidationResult result = _validator.Validate(model);

            // Assert
            result.IsValid.Should().BeFalse();
        }


        public void ProcessPayments_Validator_Valid(decimal amount, string cardHolder, string creditCard, DateTime exp, string sec)
        {
            // Arrange
            PaymentDetails model = new PaymentDetails()
            {
                Amount = amount,
                CardHolder = cardHolder,
                CreditCardNumber = creditCard,
                ExpirationDate = exp,
                SecurityCode = sec
            };

            // Act
            PaymentDetailsValidator _validator = new PaymentDetailsValidator();
            ValidationResult result = _validator.Validate(model);

            // Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
