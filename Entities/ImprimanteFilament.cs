using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class ImprimanteFilament
    {
        
        public Filament Filament { get; set; }
        public int IdFilament { get; set; }
        
        public Imprimante Imprimante { get; set; }
        public int IdImprimanta { get; set; }
    }
}
