using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class AngajatiDTO
    {
        public int IdAngajat { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public int Salariu { get; set; }
        public string Job { get; set; }

        public int IdAdresa { get; set; }
        // public Adrese Adrese { get; set; }
        // public List<DetaliiComanda> DetaliiComanda { get; set; }

        public AngajatiDTO(Angajati angajati)
        {
            this.IdAngajat = angajati.IdAngajat;
            this.Nume = angajati.Nume;
            this.Prenume = angajati.Prenume;
            this.Telefon = angajati.Telefon;
            this.Salariu = angajati.Salariu;
            this.Job = angajati.Job;

            this.IdAdresa = angajati.IdAdresa;
           // this.DetaliiComanda = new List<DetaliiComanda>();
        }



    }
}
