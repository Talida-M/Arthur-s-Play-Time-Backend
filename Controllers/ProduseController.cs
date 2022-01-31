using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTO;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.ProduseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduseController : ControllerBase
    {
        private readonly IProduseRepository _repository;
        public ProduseController(IProduseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduse()
        {
            var produse = await _repository.GetAllProduse();

            var produseToReturn = new List<ProduseDTO>();

            foreach (var produs in produse)
            {
                produseToReturn.Add(new ProduseDTO(produs));
            }

            return Ok(produseToReturn);
        }


        [HttpGet("order-by")]
        public async Task<List<ProduseDTO>> GetAllProduseWithPriceSorted()
        {
            var produse = await _repository.GetAllProduseWithPriceSorted();

            var produseToReturn = new List<ProduseDTO>();

            foreach (var produs in produse)
            {
                produseToReturn.Add(new ProduseDTO(produs));
            }

            return produseToReturn;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produs = await _repository.GetById(id);

            return Ok(new ProduseDTO(produs));
        }



        [HttpGet("Nume/{nume}")]
        public async Task<IActionResult> GetByName(string nume)
        {
            var produs = await _repository.GetByName(nume);

            return Ok(new ProduseDTO(produs));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdus(int id)
        {
            var produs = await _repository.GetById(id);

            if (produs == null)
            {
                return NotFound("Produs does not exist!");
            }

            _repository.Delete(produs);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdus(CreateProduseDTO dto)
        {
            Produs newProdus = new Produs();

            newProdus.Nume = dto.Nume;
            newProdus.PretVanzare = dto.PretVanzare;
            newProdus.CostProducere = dto.CostProducere;
            newProdus.CantitateFilament = dto.CantitateFilament;
            newProdus.Dimensiune = dto.Dimensiune;
            newProdus.CategorieId = dto.CategorieId;
            newProdus.FilamentId = dto.FilamentId;
            _repository.Create(newProdus);

            await _repository.SaveAsync();


            return Ok(new ProduseDTO(newProdus));
        }

        //de facut update






    }
}
