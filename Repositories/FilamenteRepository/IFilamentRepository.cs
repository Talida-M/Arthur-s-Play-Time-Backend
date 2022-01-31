using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.FilamenteRepository
{
    public interface IFilamentRepository : IGenericRepository<Filament>
    {
        Task<List<Filament>> GetAllFilamente();
        Task<List<Filament>> GetAllFilamentByGramajDesc();
        Task<Filament> GetByTipFilament(string tip);
        Task<dynamic> GetInformatii(int idF);

    }
}
