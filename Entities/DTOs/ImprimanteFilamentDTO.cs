using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class ImprimanteFilamentDTO
    {
        public int IdFilament { get; set; }
       // public Filament Filament { get; set; }
        public int IdImprimanta { get; set; }
      //  public Imprimante Imprimante { get; set; }
        public ImprimanteFilamentDTO(ImprimanteFilament imprimantaFilament)
        {
            this.IdFilament = imprimantaFilament.IdFilament;
          //  this.Filament = imprimantaFilament.Filament;
            this.IdImprimanta = imprimantaFilament.IdImprimanta;
          //  this.Imprimante = imprimantaFilament.Imprimante;
        }
    }
}