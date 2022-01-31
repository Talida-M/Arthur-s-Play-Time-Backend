using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTO;
using ProiectASP.Repositories.DetaliiComandaRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaliiComandaController : ControllerBase
    {
        private readonly IDetaliiComandaRepository _repository;
        public DetaliiComandaController(IDetaliiComandaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetaliiComanda()
        {
            var DCs = await _repository.GetAllDetaliiComanda();

            var dcToReturn = new List<DetaliiComandaDTO>();

            foreach (var dc in DCs)
            {
                dcToReturn.Add(new DetaliiComandaDTO(dc));
            }

            return Ok(dcToReturn);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dc = await _repository.GetById(id);

            return (IActionResult)dc;
        }

        //[HttpGet("comanda/{idC}")]
        //public async Task<IActionResult> GetProduseComanda(int idC)
        //{
        //    var dc = await _repository.GetById(idC);

        //    return Ok(new DetaliiComandaDTO(dc));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetaliiComanda(int id)
        {
            var dc = await _repository.GetById(id);

            if (dc == null)
            {
                return NotFound("Produs does not exist!");
            }

            _repository.Delete(dc);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetaliiComanda(CreateDetaliiComandaDTO dto)
        {
            DetaliiComanda newDC = new DetaliiComanda();
            newDC.IdComanda = dto.IdComanda;
            newDC.IdProdus = dto.IdProdus;
          
            newDC.IdProiectant = dto.IdProiectant;
       
            newDC.IdExecutant = dto.IdExecutant;
           
            newDC.Status = dto.Status;


            _repository.Create(newDC);

            await _repository.SaveAsync();


            return Ok(new DetaliiComandaDTO(newDC));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Proiectant, Executant, Admin")]
        public async Task<IActionResult> Update(int id, string status)
        {
            DetaliiComanda update = await _repository.GetById(id);
            update.Status = status;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
