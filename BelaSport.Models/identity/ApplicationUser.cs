using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BelaSport.Models.identity
{
    public class ApplicationUser : IdentityUser
    {
        internal ClaimsIdentity NewGuide()
        {
            throw new NotImplementedException();
        }
    }
}
