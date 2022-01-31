using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Filament
    {
        [Key]
        public int IdFilament { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TipFilament { get; set; }
        public float TemperaturaTopire { get; set; }
        public float Gramaj { get; set; }
        public ICollection<Produs> Produse { get; set; }
        public ICollection<ImprimanteFilament> ImprimanteFilamente { get; set; }
    }
}
