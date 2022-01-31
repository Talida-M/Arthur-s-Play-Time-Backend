using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Imprimante
    {
        [Key]
        public int IdImprimanta { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string Nume { get; set; }
        public float DimensiunePat { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Status { get; set; }
        public ICollection<ImprimanteFilament> ImprimanteFilamente { get; set; }

    }
}
