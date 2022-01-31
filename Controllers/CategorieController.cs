using Microsoft.AspNetCore.Mvc;
using ProiectASP.Entities;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.CategorieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
   * Needed:`
   *   GetAll
   *   GetById
   *   Update
   *   Delete
   *   Create
   */
namespace ProiectASP.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CategorieController : ControllerBase
        {
            private readonly ICategorieRepository _repository;
            public CategorieController(ICategorieRepository repository)
            {
                _repository = repository;
            }


            [HttpGet("categorie")]

            public async Task<IActionResult> GetAllCategories()
            {
                var categorii = await _repository.GetAllCategories();

                var categorieToReturn = new List<CategorieDTO>();

                foreach (var categorie in categorii)
                {
                    categorieToReturn.Add(new CategorieDTO(categorie));
                }

                return Ok(categorieToReturn);
            }

            [HttpGet("CategCuProduse/{cod}")]
            public async Task<dynamic> GetProduse(int cod)
            {
                var CP = await _repository.GetByNameCuProduse(cod);

                return CP;
            }

            [HttpGet("categoie/{id}")]

            public async Task<IActionResult> GetCategorieById(int id)
            {
                var categorie = await _repository.GetById(id);
                if (categorie == null)
                {
                    return NotFound("Nu avem categorie cu id-ul specificat");
                }
                return Ok(new CategorieDTO(categorie));
            }

            [HttpGet("categ/{name}")]
            public async Task<IActionResult> GetCategorieByName(string name)
            {
                var categorie = await _repository.GetCatgByName(name);
                if (categorie == null)
                {
                    return NotFound("Nu avem categorie cu numele specificat");
                }
                return Ok(new CategorieDTO(categorie));
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategorie(CreateCategorieDTO creare)
            {
                Categorie newCategorie = new Categorie();
                newCategorie.IdCategorie = creare.IdCategorie;
                newCategorie.Nume = creare.Nume;
                //  newCategorie.Produse = creare.Produse;

                _repository.Create(newCategorie);
                await _repository.SaveAsync();

                return Ok(new CategorieDTO(newCategorie));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategorie(int id)
            {
                var categorie = await _repository.GetById(id);
                if (categorie == null)
                {
                    return NotFound("Categoria nu exista.");
                }
                _repository.Delete(categorie);

                await _repository.SaveAsync();

                return NoContent();


            }

            [HttpPatch("{id}")]
            public async Task<IActionResult> UpdateNumeCategorie(int id, string name)
            {
                Categorie update = await _repository.GetById(id);
                update.Nume = name;
                _repository.Update(update);
                await _repository.SaveAsync();
                return NoContent();
            }


        }
    }

