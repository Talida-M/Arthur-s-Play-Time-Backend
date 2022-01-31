using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.ImprimanteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
        [Controller]
    public class ImprimanteController : ControllerBase
    {
        private readonly IImprimantaRepository _repository;
        public ImprimanteController(IImprimantaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllImprimante()
        {
            var imprimante = await _repository.GetAllImprimante();

            var imprimanteToReturn = new List<ImprimanteDTO>();

            foreach (var imprimanta in imprimante)
            {
                imprimanteToReturn.Add(new ImprimanteDTO(imprimanta));
            }

            return Ok(imprimanteToReturn);
        }

        [HttpGet("imprimante/{status}")]

        public async Task<IActionResult> GetImprimanteByStatus(string status)
        {
            List<Imprimante> imprimanta = await _repository.GetImprimanteDupaStatus(status);
            if (imprimanta == null)
            {
                return NotFound("Nu avem imprimante cu statusul dat.");
            }
            return Ok(imprimanta);
        }

        [HttpPost("imprimanta")]
        public async Task<IActionResult> CreateImprimanta(CreateImprimanteDTO creare)
        {
            Imprimante newImprimante = new Imprimante();
            newImprimante.IdImprimanta = creare.IdImprimanta;
            newImprimante.Nume = creare.Nume;
            newImprimante.Status = creare.Status;
            newImprimante.DimensiunePat = creare.DimensiunePat;
            //  newCategorie.Produse = creare.Produse;

            _repository.Create(newImprimante);
            await _repository.SaveAsync();

            return Ok(new ImprimanteDTO(newImprimante));
        }

        [HttpDelete("{idImp}")]
        public async Task<IActionResult> DeleteImprimanta(int idImp)
        {
            var imprimanta = await _repository.GetById(idImp);
            if (imprimanta == null)
            {
                return NotFound("Imprimanta nu exista.");
            }
            _repository.Delete(imprimanta);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{idI}")]
        public async Task<IActionResult> UpdateStatusImprimante(int idI, string statusNou)
        {
            Imprimante update = await _repository.GetById(idI);
            update.Status = statusNou;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}
