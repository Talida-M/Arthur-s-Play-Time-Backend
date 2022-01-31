
using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class DetaliiComanda
    {
        
        public Comenzi Comenzi { get; set; }
        public int IdComanda { get; set; }

        
        public Produs Produse { get; set; }
        public int IdProdus { get; set; }

        public int IdProiectant { get; set; }
        public Angajati Angajati { get; set; }
        public int IdExecutant { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }
    }
}
