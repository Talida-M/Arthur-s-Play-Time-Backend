using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        //  public string Mail { get; set; }
        public string Rol { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }    
    }
}
