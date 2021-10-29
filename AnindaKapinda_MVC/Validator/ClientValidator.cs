using AnindaKapinda_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Validator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                                     .MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty()
                                    .MaximumLength(20);
            RuleFor(x => x.Email).EmailAddress();
            
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
            RuleFor(x => x.PasswordConfirmation).Equal(x=>x.Password);
        }
    }  
}
