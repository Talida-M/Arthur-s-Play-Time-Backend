using Microsoft.EntityFrameworkCore;
using ProiectASP.Repositories.AngajatiRepository;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.AngajatiRepository
{
    public class AngajatiRepository : GenericRepository<Angajati>, IAngajatiRepository
    {
        public AngajatiRepository(Context context) : base(context) { }


        public async Task<List<Angajati>> GetAllAngajati()
        {
            return await _context.Angajati.ToListAsync();
        }

        public async Task<Angajati> GetByIdA(int id)
        {
            return await _context.Angajati.Where(a => a.IdAngajat.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Angajati> GetByIdWithAdresa(int id)
        {
             return await _context.Angajati.Include(a => a.Adrese).Where(a => a.IdAngajat == id).FirstOrDefaultAsync();
         }
    }
}
