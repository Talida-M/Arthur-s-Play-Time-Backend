using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class CreateComenziDTO
    {
        public string Data { get; set; }
        public float Valoare { get; set; }
        public string StatusTotal { get; set; }
        public int ClientId { get; set; }


        //  public Clienti Clienti { get; set; }
        // public List<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
