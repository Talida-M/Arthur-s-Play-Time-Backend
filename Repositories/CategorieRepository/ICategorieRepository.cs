using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.CategorieRepository
{
    public interface ICategorieRepository : IGenericRepository<Categorie>
    {
        Task<Categorie> GetCatgByName(string nume);
        Task<dynamic> GetByNameCuProduse(int cod);
        Task<List<Categorie>> GetAllCategories();
        Task<Categorie> GetByCod(int cod);
    }
}
