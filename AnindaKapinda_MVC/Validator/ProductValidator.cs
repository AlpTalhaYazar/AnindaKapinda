using AnindaKapinda_MVC.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                .MaximumLength(50);
            
        }

        //public bool IsProductUnique(Product editedProduct, string newValue)
        //{
        //    return _products.All(x => x.Equals(editedProduct) || x.Name != newValue);
        //}
    }  
}
