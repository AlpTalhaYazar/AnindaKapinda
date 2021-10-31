using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.CustomValidator
{
    public class CustomPasswordValidator : PasswordValidator<IdentityUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> asd =  new List<IdentityError>();
            
            if (password.Length < 8) 
                asd.Add(new IdentityError { Code = "PasswordLength", Description = "Password length must be at least 8." });
            if (!password.Contains(@"[A-Z]+"))
                asd.Add(new IdentityError { Code = "PasswordContent", Description = "Password must contain at least 1 uppercase." });

            return asd.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(asd.ToArray());
        }
    }
}
