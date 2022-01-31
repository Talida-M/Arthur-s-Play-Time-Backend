using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ClientiRepository
{
    public class ClientiRepository : GenericRepository<Clienti>, IClientiRepository
    {
        public ClientiRepository(Context context) : base(context) { }


        public async Task<List<Clienti>> GetAllClienti()
        {
            return await _context.Clienti.ToListAsync();
        }

        public async Task<Clienti> GetByIdClient(int id)
        {
            return await _context.Clienti.Where(a => a.IdClient.Equals(id)).FirstOrDefaultAsync();
        }


        public async Task<List<string>> GetByIdWithComenzi(int id)
        {
            return await _context.Clienti.Where(a => a.IdClient.Equals(id)).Join(_context.Comenzi,
                                                                                        comanda => comanda.IdClient,
                                                                                        cl => cl.ClientId,
                                                                                        (Clienti, Comenzi) => new
                                                                                        {
                                                                                            IdClient = Clienti.IdClient,
                                                                                            Data = Comenzi.Data
                                                                                            
                                                                                        }
                                                                                        )
                .Select(a => a.Data)
                .ToListAsync();


        }

    }
}
