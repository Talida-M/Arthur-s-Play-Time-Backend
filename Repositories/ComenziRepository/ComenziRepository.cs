using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ComenziRepository
{
    public class ComenziRepository : GenericRepository<Comenzi>, IComenziRepository
    {
        public ComenziRepository(Context context) : base(context) { }


        public async Task<List<Comenzi>> GetAllComenzi() 
        {
            return await _context.Comenzi.ToListAsync();
        }

        public async Task<Comenzi> GetByIdC(int id)
        {
            return await _context.Comenzi.Where(a => a.IdComanda.Equals(id)).FirstOrDefaultAsync();
        }

    }
}
