using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.AngajatiRepository
{
    public interface IAngajatiRepository : IGenericRepository<Angajati>
    {
        Task<Angajati> GetByIdA(int id); //ok
        Task<List<Angajati>> GetAllAngajati(); //ok
        Task<Angajati> GetByIdWithAdresa(int id);
    }
}
