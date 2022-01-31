using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ImprimanteRepository
{
   public  interface IImprimantaRepository : IGenericRepository<Imprimante>
    {
        Task<List<Imprimante>> GetAllImprimante();
        Task<List<Imprimante>> GetImprimanteDupaStatus(string status);
        

    }
}
