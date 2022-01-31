using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class CreateProduseDTO
    {
        public string Nume { get; set; }
        public float PretVanzare { get; set; }
        public float CostProducere { get; set; }
        public float CantitateFilament { get; set; }
        public float Dimensiune { get; set; }
        public int CategorieId { get; set; }
        public int FilamentId { get; set; }


    }
}
