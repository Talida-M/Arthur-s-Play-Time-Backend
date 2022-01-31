using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class ImprimanteDTO
    {
        public int IdImprimanta { get; set; }
        public string Nume { get; set; }
        public float DimensiunePat { get; set; }
        public string Status { get; set; }
       // public List<ImprimanteFilament> ImprimanteFilamente { get; set; }

        public ImprimanteDTO(Imprimante imprimanta)
        {
            this.IdImprimanta = imprimanta.IdImprimanta;
            this.Nume = imprimanta.Nume;
            this.DimensiunePat = imprimanta.DimensiunePat;
            this.Status = imprimanta.Status;
         //   this.ImprimanteFilamente = new List<ImprimanteFilament>();
        }
    }
}
