using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTO;
using ProiectASP.Repositories.ComenziRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController : ControllerBase
    {
        private readonly IComenziRepository _repository;
        public ComenziController(IComenziRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComenzi()
        {
            var comenzi = await _repository.GetAllComenzi();

            var comenziToReturn = new List<ComenziDTO>();

            foreach (var comanda in comenzi)
            {
                comenziToReturn.Add(new ComenziDTO(comanda));
            }

            return Ok(comenziToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comenzi = await _repository.GetById(id);

            return Ok(new ComenziDTO(comenzi));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComenzi(int id)
        {
            var comanda = await _repository.GetById(id);

            if (comanda == null)
            {
                return NotFound("Comanda does not exist!");
            }

            _repository.Delete(comanda);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComanda(CreateComenziDTO dto)
        {
            Comenzi newComenzi = new Comenzi();

            newComenzi.Data = dto.Data;
            newComenzi.Valoare = dto.Valoare;
            newComenzi.StatusTotal = dto.StatusTotal;
            newComenzi.ClientId = dto.ClientId;

            _repository.Create(newComenzi);

            await _repository.SaveAsync();


            return Ok(new ComenziDTO(newComenzi));
        }

        [HttpPatch("{id}")]
       // [Authorize(Roles = "Proiectant, Executant, Admin")]
        public async Task<IActionResult> Update(int id, string statusTotal)
        {
            Comenzi update = await _repository.GetById(id);
            update.StatusTotal = statusTotal;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}
