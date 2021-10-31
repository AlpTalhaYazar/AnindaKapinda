﻿using AnindaKapinda_MVC.Models;
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
            RuleFor(x => x.PhoneNumber).NotEmpty()
                                       .Matches(@"^(\+[0-9]{12})$").WithMessage("This number is invalid.");
            RuleFor(x => x.Email).EmailAddress();            
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                                    .MinimumLength(8).WithMessage("Passwords must be at least 8 characters.")
                                    .Matches(@"[A-Z]+").WithMessage("Passwords must have at least one uppercase ('A'-'Z').")
                                    .Matches(@"[a-z]+").WithMessage("Passwords must have at least one lowercase ('a'-'z').")
                                    .Matches(@"[0-9]+").WithMessage("Passwords must have at least one digit ('0'-'9').");
        }
    }  
}
