using AnindaKapinda_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                                     .MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty()
                                    .MaximumLength(20);
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.PhoneNumber).Matches(@"^(\+[0-9]{12})$").WithMessage("This number is invalid.");
            RuleFor(x => x.Email).EmailAddress();            
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }  
}
