using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class CreateDetaliiComandaDTO
    {
        public int IdComanda { get; set; }
        
        public int IdProdus { get; set; }
       
        public int IdProiectant { get; set; }
       
        public int IdExecutant { get; set; }
        public string Status { get; set; }
    }
}
