using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.DetaliiComandaRepository
{
    public class DetaliiComandaRepository : GenericRepository<DetaliiComanda>, IDetaliiComandaRepository
    { 
        public DetaliiComandaRepository(Context context) : base(context) { }

        public async Task<List<DetaliiComanda>> GetAllDetaliiComanda()
        {
            return await _context.DetaliiComanda.ToListAsync();
        }


        public async Task<DetaliiComanda> GetByIdDC(int id)
        {
            return await _context.DetaliiComanda.Where(a => a.IdComanda.Equals(id)).FirstOrDefaultAsync();
        }

        //public async Task<dynamic> GetProduseComanda(int id)
        //{
        //    var result = from comenzi in _context.Comenzi 
        //                 join detalii in _context.DetaliiComanda
        //                 on comenzi.IdComanda equals detalii.IdComanda

        //                 select new
        //                 {
        //                     idC = comenzi.IdComanda,
        //                     idP = detalii.IdProdus,                      
        //                     status = comenzi.StatusTotal,
        //                     data = comenzi.Data,
        //                     client = comenzi.ClientId


        //                 };
        //   var final = result.AsEnumerable().Distinct().GroupBy(i => i.idC);
        //    return final;
        //}
        //    public async Task<List<string>> GetAllProduseDinComanda(int id)
                
        //{
        //    return await _context.DetaliiComanda.Where(a => a.IdComanda.Equals(id)).Join(_context.Produse, 
        //                                                                                comanda => comanda.IdProdus,
        //                                                                                prod => prod.IdProdus,
        //                                                                                (DetaliiComanda,Produse) => new
        //                                                                                {
        //                                                                                    IdProdus=Produse.IdProdus,
        //                                                                                    Nume = Produse.Nume
        //                                                                                }
        //                                                                                )
        //        .Select(a =>a.Nume)
        //        .ToListAsync();
         

        //}

       }
}
