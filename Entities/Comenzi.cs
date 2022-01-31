using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities
{
    public class Comenzi
    {
        [Key]
        public int IdComanda { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Data { get; set; }
        public float Valoare { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string StatusTotal { get; set; }

        
        public Clienti Clienti { get; set; }
        public int ClientId { get; set; }

        public ICollection<DetaliiComanda> DetaliiComanda { get; set; }
    }
}
