using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ProduseRepository
{
    public class ProduseRepository : GenericRepository<Produs>, IProduseRepository
    {
        
        public ProduseRepository(Context context) : base(context) { }


        public async Task<List<Produs>> GetAllProduse()
            {
                return await _context.Produse.ToListAsync();
            }

            
            public async Task<List<Produs>> GetAllProduseWithPriceSorted()
            {
                return await _context.Produse.OrderBy(x => x.PretVanzare).ToListAsync();
            }

        
        public async Task<Produs> GetByName(string name)
        {
            return await _context.Produse.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<Produs> GetByIdP(int id)
        {
            return await _context.Produse.Where(a => a.IdProdus.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
