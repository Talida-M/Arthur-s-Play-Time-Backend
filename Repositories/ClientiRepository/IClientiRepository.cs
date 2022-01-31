using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ClientiRepository
{
    public interface IClientiRepository : IGenericRepository<Clienti>
    {
        
            Task<Clienti> GetByIdClient(int id); 
            Task<List<Clienti>> GetAllClienti(); 
            Task<List<string>> GetByIdWithComenzi(int id);
        
    }
}
