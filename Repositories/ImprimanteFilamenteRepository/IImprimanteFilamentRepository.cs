using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.ImprimanteFilamenteRepository
{
    public interface IImprimanteFilamentRepository : IGenericRepository<ImprimanteFilament>
    {
        Task<List<ImprimanteFilament>> GetAllImprimanteFilamente();
        Task<ImprimanteFilament> GetByIdFilament(int idF);
        Task<ImprimanteFilament> GetByIdImprimants(int idI);

        Task<dynamic> GetProdusSiImprimantaSiTipFilament(int codF);
    }
}
