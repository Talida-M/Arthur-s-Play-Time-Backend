using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTOs
{
    public class CategorieDTO
    {
        public int IdCategorie { get; set; }
        public string Nume { get; set; }
       // public List<Produse> Produse { get; set; }
        public CategorieDTO(Categorie categorie)
        {
            this.IdCategorie = categorie.IdCategorie;
            this.Nume = categorie.Nume;
           // this.Produse = new List<Produse>();
        }
    }
}
