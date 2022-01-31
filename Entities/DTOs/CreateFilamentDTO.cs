using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class CreateFilamentDTO
    {
        public int IdFilament { get; set; }
        public string TipFilament { get; set; }
        public float TemperaturaTopire { get; set; }
        public float Gramaj { get; set; }
        //public List<Produse> Produse { get; set; }
        //public List<ImprimanteFilament> ImprimanteFilamente { get; set; }

    }
}
