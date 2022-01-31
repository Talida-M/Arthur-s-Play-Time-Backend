using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTO;
using ProiectASP.Repositories.AngajatiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AngajatiController : ControllerBase
    {
        private readonly IAngajatiRepository _repository;
        public AngajatiController(IAngajatiRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
       // [AllowAnonymous]
        public async Task<IActionResult> GetAllAngajati()
        {
            var ang = await _repository.GetAllAngajati();

            var angToReturn = new List<AngajatiDTO>();

            foreach (var angajat in ang)
            {
                angToReturn.Add(new AngajatiDTO(angajat));
            }

            return Ok(angToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var ang = await _repository.GetById(id);

            return Ok(new AngajatiDTO(ang));
        }

        [HttpGet("cuAdresa/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdWithAdresa(int id)
        {
            var angajat = await _repository.GetByIdWithAdresa(id);

            return Ok(new AngajatiDTO(angajat));
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAngajati(int id)
        {
            var ang = await _repository.GetById(id);

            if (ang == null)
            {
                return NotFound("Angajat does not exist!");
            }

            _repository.Delete(ang);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAngajati(CreateAngajatiDTO dto)
        {
            Angajati newAngajati = new Angajati();

            newAngajati.Nume = dto.Nume;
            newAngajati.Prenume = dto.Prenume;
            newAngajati.Telefon = dto.Telefon;
            newAngajati.Salariu = dto.Salariu;
            newAngajati.Job = dto.Job;
            newAngajati.IdAdresa = dto.IdAdresa;

            //  newAngajati.Adrese = dto.Adrese;IdAdresa

            _repository.Create(newAngajati);

            await _repository.SaveAsync();


            return Ok(new AngajatiDTO(newAngajati));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, int salariuNou)
        {
            Angajati update = await _repository.GetById(id);
            update.Salariu = salariuNou;
            _repository.Update(update);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
