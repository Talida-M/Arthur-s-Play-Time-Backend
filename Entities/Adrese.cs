using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Adrese
    {
        [Key]
        public int IdAdresa { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Oras { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Strada { get; set; }

        public int IdAngajat { get; set; }
        public Angajati Angajati { get; set; }
    }
}
