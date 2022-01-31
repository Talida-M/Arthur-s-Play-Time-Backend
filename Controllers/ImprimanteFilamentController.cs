using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.ImprimanteFilamenteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    public class ImprimanteFilamentController : ControllerBase
    {
        private readonly IImprimanteFilamentRepository _repository;
        public ImprimanteFilamentController(IImprimanteFilamentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ImprimanteFilament")]
        [Authorize(Roles = "Proiectant, Executant, Admin")]
        public async Task<IActionResult> GetAllCategories()
        {
            var impFlm = await _repository.GetAllImprimanteFilamente();

            var impFlmToReturn = new List<ImprimanteFilamentDTO>();

            foreach (var imprimantaFilament in impFlm)
            {
                impFlmToReturn.Add(new ImprimanteFilamentDTO(imprimantaFilament));
            }

            return Ok(impFlmToReturn);
        }

        [HttpGet("ImprimanteFilament/{idF}")]

        public async Task<IActionResult> GetImprimanteFilamenteByIdF(int idF)
        {
            var impF = await _repository.GetByIdFilament(idF);
            if (impF == null)
            {
                return NotFound("Nu exista compatibilitatea cu id-ul dat");
            }
            return Ok(new ImprimanteFilamentDTO(impF));
        }

        [HttpGet("GetInformatii/{idF}")]
        public async Task<dynamic> GetInformatii(int idF)
        {
            var impF = await _repository.GetProdusSiImprimantaSiTipFilament(idF);
   
            return impF;
        }

        [HttpGet("ImprimanteFilament/{idI}")]

        public async Task<IActionResult> GetImprimanteFilamenteByIdI(int idI)
        {
            var impF = await _repository.GetByIdImprimants(idI);
            if (impF == null)
            {
                return NotFound("Nu exista compatibilitatea cu id-ul dat");
            }
            return Ok(new ImprimanteFilamentDTO(impF));
        }

        [HttpPost("ImprimanteFilament")]
      //  [Authorize(Roles = "Proiectant, Executant, Admin")]
        public async Task<IActionResult> CreateImprimanteFilament(CreateImprimanteFilamentDTO creare)
        {
            ImprimanteFilament newImprimanteFilament = new ImprimanteFilament();
            newImprimanteFilament.IdFilament = creare.IdFilament;
            newImprimanteFilament.IdImprimanta = creare.IdImprimanta;


            _repository.Create(newImprimanteFilament);
            await _repository.SaveAsync();

            return Ok(new ImprimanteFilamentDTO(newImprimanteFilament));
        }

        [HttpDelete("{idIF}")]
        [Authorize(Roles = "Proiectant, Executant, Admin")]
        public async Task<IActionResult> DeleteCategorie(int idIF)
        {
            var ImprimanteFilament = await _repository.GetById(idIF);
            if (ImprimanteFilament == null)
            {
                return NotFound("Nu exista.");
            }
            _repository.Delete(ImprimanteFilament);

            await _repository.SaveAsync();

            return NoContent();


        }

        
    }
}
