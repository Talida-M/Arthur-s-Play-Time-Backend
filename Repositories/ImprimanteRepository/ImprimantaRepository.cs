using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ImprimanteRepository
{
    public class ImprimantaRepository : GenericRepository<Imprimante>, IImprimantaRepository
    {

        public ImprimantaRepository(Context context) : base(context) { }

        public async Task<List<Imprimante>> GetAllImprimante()
        {
            return await _context.Imprimante.ToListAsync();

        }


        public async Task<List<Imprimante>> GetImprimanteDupaStatus(string status)
        {
            var imprimanta = await _context.Imprimante.Where(a => a.Status.Equals(status)).ToListAsync();
            return imprimanta;
        }
    }
}
