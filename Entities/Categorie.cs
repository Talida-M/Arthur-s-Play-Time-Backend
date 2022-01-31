using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Nume { get; set; }
        public ICollection<Produs> Produse { get; set; }

    }
}
