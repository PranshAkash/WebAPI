using Microsoft.AspNetCore.Identity;
using System;

namespace Services.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string IdString
        {
            get
            {
                return Id.ToString();
            }
        }
    }
}
