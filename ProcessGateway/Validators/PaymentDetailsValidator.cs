using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProcessGateway.Models;
using Microsoft.EntityFrameworkCore;


namespace ProcessGateway.Validators
{
    public class PaymentDetailsValidator : AbstractValidator<PaymentDetails>
    {
        public PaymentDetailsValidator()
        {
            RuleFor(user => user.CreditCardNumber).NotNull().CreditCard();
            RuleFor(user => user.CardHolder).NotNull().MinimumLength(2).MaximumLength(99);
            RuleFor(user => user.ExpirationDate).GreaterThan(DateTime.Now);
            RuleFor(user => user.SecurityCode).NotNull().MaximumLength(3).MaximumLength(10);
            RuleFor(user => user.Amount).GreaterThan(0).NotNull();
        }
    }
}
