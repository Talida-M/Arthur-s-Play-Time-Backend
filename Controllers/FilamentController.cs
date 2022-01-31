using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.FilamenteRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilamentController : ControllerBase
    {
        private readonly IFilamentRepository _repository;
        public FilamentController(IFilamentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("filamente")]
        public async Task<IActionResult> GetAllFilamente()
        {
            var filamente = await _repository.GetAllFilamente();

            var filamenteToReturn = new List<FilamentDTO>();

            foreach (var filament in filamente)
            {
                filamenteToReturn.Add(new FilamentDTO(filament));
            }

            return Ok(filamenteToReturn);
        }

        [HttpGet("filamenteGramaj")]
        public async Task<IActionResult> GetAllFilamenteByGramaj()
        {
            var filamente = await _repository.GetAllFilamentByGramajDesc();

            var filamenteToReturn = new List<FilamentDTO>();

            foreach (var filament in filamente)
            {
                filamenteToReturn.Add(new FilamentDTO(filament));
            }

            return Ok(filamenteToReturn);
        }

        [HttpGet("filamente/{tip}")]

        public async Task<IActionResult> GetFilamenteDupaTip(string tip)
        {
            var filamente = await _repository.GetByTipFilament(tip);
            if (filamente == null)
            {
                return NotFound("Nu avem filamente de tipul specificat");
            }
            return Ok(new FilamentDTO(filamente));
        }

        [HttpGet("infoFilamente/{idF}")]

        public async Task<dynamic> GetInfo(int idF)
        {
            var  filamente = await _repository.GetInformatii(idF);
      
            return filamente;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilament(CreateFilamentDTO creare)
        {
            Filament newFilament = new Filament();
            newFilament.IdFilament = creare.IdFilament;
            newFilament.TipFilament = creare.TipFilament;
            newFilament.TemperaturaTopire = creare.TemperaturaTopire;
            newFilament.Gramaj = creare.Gramaj;
            //newFilament.ImprimanteFilamente = creareF.ImprimanteFilamente;
            //newFilament.Produse = creareF.Produse;

            _repository.Create(newFilament);
            await _repository.SaveAsync();

            return Ok(new FilamentDTO(newFilament));
        }

        [HttpDelete("{cod}")]
        public async Task<IActionResult> DeleteCategorie(int cod)
        {
            var filament = await _repository.GetById(cod);
            if (filament == null)
            {
                return NotFound("Filamentul nu exista.");
            }
            _repository.Delete(filament);

            await _repository.SaveAsync();

            return NoContent();
        }


        [HttpPatch("{codFilament}")]
        public async Task<IActionResult> UpdateGramajFilament(int cod, float gr)
        {
            Filament update = await _repository.GetById(cod);
            update.Gramaj = gr;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}
