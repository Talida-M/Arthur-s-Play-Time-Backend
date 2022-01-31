using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ComenziRepository
{
    public interface IComenziRepository : IGenericRepository<Comenzi>
    {
        Task<Comenzi> GetByIdC(int id); //
        Task<List<Comenzi>> GetAllComenzi(); //

 
    }
}
