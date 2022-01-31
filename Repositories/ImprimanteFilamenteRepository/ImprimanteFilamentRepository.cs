using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ImprimanteFilamenteRepository
{
    public class ImprimanteFilamentRepository : GenericRepository<ImprimanteFilament>, IImprimanteFilamentRepository
    {

        public ImprimanteFilamentRepository(Context context) : base(context) { }


        public async Task<List<ImprimanteFilament>> GetAllImprimanteFilamente()
        {
            return await _context.ImprimanteFilament.ToListAsync();
        }
        public async Task<ImprimanteFilament> GetByIdFilament(int idF)
        {
            return await _context.ImprimanteFilament.Where(a => a.IdFilament.Equals(idF)).FirstOrDefaultAsync();

        }
        public async Task<ImprimanteFilament> GetByIdImprimants(int idI)
        {
            return await _context.ImprimanteFilament.Where(a => a.IdFilament.Equals(idI)).FirstOrDefaultAsync();

        }

        /////Sa se afiseze numele produsului si numele imprimantei compatibile

        public async Task<dynamic> GetProdusSiImprimantaSiTipFilament(int codF)
        {
            var result = from produs in _context.Produse 
                         join imprimantafilament in _context.ImprimanteFilament
                         on produs.FilamentId equals codF
                   
                         select new
                         {
                             IdF = imprimantafilament.IdFilament,
                             nume = produs.Nume,
                             //tipFilament = filament.TipFilament,
                            
                             codImprimanta = imprimantafilament.IdImprimanta
                         };
            var  final = result.AsEnumerable().GroupBy(i => i.codImprimanta);
            //var rez1 = new List<dynamic>();
            //foreach  (var group in final)
            //{
            //    var rez2 = new List<dynamic>();
            //    foreach (var i in group)
            //    {
            //        rez2.Add(i);
            //    }

            //    rez1.Add(rez2);

            //}
            return final;
            //return result.GroupBy(i => i.codImprimanta);
                //Where(i => i.IdF == codF ).Distinct();

        }
        //    return await _context.ImprimanteFilament
        //        .GroupJoin(_context.Imprimante, _context.Produse, _context.Filament,
        //         prod => prod.IdFilament,
        //         filament => filament.IdFilament,
        //         impFlm => impFlm.IdFilament,
        //         imp => imp.IdImprimanta,
        //         (prod, filament, impFlm, imp) => new
        //         {
        //             IdFilament = impFlm.IdFilament,
        //             Nume = prod.Nume,
        //             TipFilament = filament.TipFilament,
        //             Nume = imp.Nume
        //         }
        //         )
        //         .Where(a => a.IdFilament == codF)
        //         .ToListAsync();
        //}
    }
}
