using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.DetaliiComandaRepository
{
    public interface IDetaliiComandaRepository : IGenericRepository<DetaliiComanda>
    {
        Task<DetaliiComanda> GetByIdDC(int id); //
        Task<List<DetaliiComanda>> GetAllDetaliiComanda(); //
        //Task<dynamic> GetProduseComanda(int id);
       // Task<List<string>> GetAllProduseFromComanda(int id); 
    }
}
