using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class ClientiDTO
    {
        public int IdClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        //public List<Comenzi> Comenzi { get; set; }

        public ClientiDTO(Clienti clienti)
        {
            this.IdClient = clienti.IdClient;
            this.Nume = clienti.Nume;
            this.Prenume = clienti.Prenume;
            this.Telefon = clienti.Telefon;
            this.Mail = clienti.Mail;
            

          //  this.Comenzi = new List<Comenzi>();
        }
    }
}
