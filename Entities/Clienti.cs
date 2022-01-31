using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Clienti 
    {
       

        [Key]
        public int IdClient { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nume { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Prenume { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Telefon { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Mail { get; set; }

        public ICollection<Comenzi> Comenzi { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
