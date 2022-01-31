using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class ComenziDTO
    {
        public int IdComanda { get; set; }
        public string Data { get; set; }
        public float Valoare { get; set; }
        public string StatusTotal { get; set; }
        public int IdClient { get; set; }


        // public Clienti Clienti { get; set; }

       // public List<DetaliiComanda> DetaliiComanda { get; set; }


        public ComenziDTO(Comenzi comenzi)
        {
            this.IdComanda = comenzi.IdComanda;
            this.Data = comenzi.Data;
            this.Valoare = comenzi.Valoare;
            this.StatusTotal = comenzi.StatusTotal;
            
            this.IdClient = comenzi.ClientId;
          //  this.DetaliiComanda = new List<DetaliiComanda>();
        }

    }
}
