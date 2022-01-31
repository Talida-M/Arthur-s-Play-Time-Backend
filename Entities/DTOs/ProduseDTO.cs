using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class ProduseDTO
    {
        public int IdProdus { get; set; }
        public string Nume { get; set; }
        public float PretVanzare { get; set; }
        public float CostProducere { get; set; }
        public float CantitateFilament { get; set; }
        public float Dimensiune { get; set; }
        public int CategorieId { get; set; }
        public int FilamentId { get; set; }
        //public List<DetaliiComanda> DetaliiComanda { get; set; }
        public ProduseDTO(Produs produse)
        {
            this.IdProdus = produse.IdProdus;
            this.Nume = produse.Nume;
            this.PretVanzare = produse.PretVanzare;
            this.CostProducere = produse.CostProducere;
            this.CantitateFilament = produse.CantitateFilament;
            this.Dimensiune = produse.Dimensiune;
            this.CategorieId = produse.CategorieId;
            this.FilamentId = produse.FilamentId;
            // this.DetaliiComanda = new List<DetaliiComanda>();




        }
    }
}
