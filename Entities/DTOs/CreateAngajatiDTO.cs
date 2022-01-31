using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class CreateAngajatiDTO
    {
        public int IdAngajat { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public int Salariu { get; set; }
        public string Job { get; set; }

        public int IdAdresa { get; set; }
        // public Adrese Adrese { get; set; }
        //public List<DetaliiComanda> DetaliiComanda { get; set; }

    }
}
