using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class FilamentDTO
    {
        public int IdFilament { get; set; }
        public string TipFilament { get; set; }
        public float TemperaturaTopire { get; set; }
        public float Gramaj { get; set; }
        //public List<Produse> Produse { get; set; }
        //public List<ImprimanteFilament> ImprimanteFilamente { get; set; }


        public FilamentDTO(Filament filament)
        {
            this.IdFilament = filament.IdFilament;
            this.TipFilament = filament.TipFilament;
            this.TemperaturaTopire = filament.TemperaturaTopire;
            this.Gramaj = filament.Gramaj;
            //this.Produse = new List<Produse>();
            //this.ImprimanteFilamente = new List<ImprimanteFilament>();


        }
    }
}
