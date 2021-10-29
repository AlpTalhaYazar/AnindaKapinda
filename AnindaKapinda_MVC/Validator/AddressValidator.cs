using AnindaKapinda_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City).NotEmpty()
                                .MaximumLength(20);
            RuleFor(x => x.District).NotEmpty()
                                    .MaximumLength(20);
            RuleFor(x => x.Detail).NotEmpty()
                                  .MaximumLength(150);
            
        }
    }  
}
