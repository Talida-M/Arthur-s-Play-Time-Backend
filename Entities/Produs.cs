using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Produs
    {
        [Key]
        public int IdProdus { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Nume { get; set; }
        public float PretVanzare { get; set; }
        public float CostProducere { get; set; }
        public float CantitateFilament { get; set; }
        public float Dimensiune { get; set; }

        public Categorie Categorii { get; set; }
        public int CategorieId { get; set; }
        public Filament Filamente { get; set; }
        public int FilamentId { get; set; }

        public ICollection<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
