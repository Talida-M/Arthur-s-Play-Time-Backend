using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ProduseRepository
{
    public interface IProduseRepository : IGenericRepository<Produs>
    {
            Task<Produs> GetByName(string nume); //ok
            Task<Produs> GetByIdP(int id); //ok
            Task<List<Produs>> GetAllProduse(); //ok
            Task<List<Produs>> GetAllProduseWithPriceSorted(); //ruleaza dar nu afis
          //  Task<Produse> GetByIdWithImprimanta();


    }
}
