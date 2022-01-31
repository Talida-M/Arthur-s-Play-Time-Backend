using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class DetaliiComandaDTO
    {
        public int IdComanda { get; set; }


        public int IdProdus { get; set; }
       

        public int IdProiectant { get; set; }

        public int IdExecutant { get; set; }
        public string Status { get; set; }


        public DetaliiComandaDTO(DetaliiComanda detalii_comanda)
        {
            this.IdComanda = detalii_comanda.IdComanda;
            this.IdProdus = detalii_comanda.IdProdus;
     
            this.IdProiectant = detalii_comanda.IdProiectant;
   
            this.IdExecutant = detalii_comanda.IdExecutant;
            this.Status = detalii_comanda.Status;
        }
    }
}
