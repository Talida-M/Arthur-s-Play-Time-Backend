using Microsoft.EntityFrameworkCore;
using ProiectASP.Data;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.CategorieRepository
{
    public class CategorieRepository : GenericRepository<Categorie>, ICategorieRepository
    {
        // private Context context;
        public CategorieRepository(Context context) : base(context)
        {
        }

        public async Task<List<Categorie>> GetAllCategories()
        {
            var categorii = await _context.Categorie.ToListAsync();
            return categorii;
        }

        public async Task<Categorie> GetByCod(int cod)
        {
            return await _context.Categorie.Where(a => a.IdCategorie.Equals(cod)).FirstOrDefaultAsync();

        }


        public async Task<Categorie> GetCatgByName(string name)
        {
            return await _context.Categorie.Where(a => a.Nume.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<dynamic> GetByNameCuProduse(int cod)
        {

            var result = from produs in _context.Produse
                         join categorie in _context.Categorie
                         on produs.CategorieId equals cod


                         select new
                         {
                             id = produs.IdProdus,
                             nume = produs.Nume,
                             pret = produs.PretVanzare

                         };
            var final = result.AsEnumerable().Distinct();

            return final;
        }
    }
}