using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class CreateImprimanteDTO
    {
        public int IdImprimanta { get; set; }
        public string Nume { get; set; }
        public float DimensiunePat { get; set; }
        public string Status { get; set; }
    }
}
