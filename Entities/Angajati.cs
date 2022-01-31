using Microsoft.AspNetCore.Identity;
using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Angajati 
    {

        [Key]
        public int IdAngajat { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Nume { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Prenume { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Telefon { get; set; }
        public int Salariu { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Job { get; set; }

        public int IdAdresa { get; set; }
        public Adrese Adrese { get; set; }

        public ICollection<DetaliiComanda> DetaliiComanda { get; set; }

        //public ICollection<UserRole> UserRoles { get; set; }
       // public Angajati() : base() { }

       
    }
}
