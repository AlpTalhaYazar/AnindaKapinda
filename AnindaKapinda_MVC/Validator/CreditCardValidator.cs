using AnindaKapinda_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Validator
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CardName).NotEmpty()
                                    .MaximumLength(20);
            RuleFor(x => x.CardNumber).NotEmpty()
                                      .MaximumLength(20);
            RuleFor(x => x.ExpirationDate).NotEmpty()
                                          .MaximumLength(5);
            RuleFor(x => x.CardHolder).NotEmpty()
                                      .MaximumLength(20);
            RuleFor(x => x.SecurityCode).NotEmpty()
                                        .MaximumLength(4);
        }
    }  
}
