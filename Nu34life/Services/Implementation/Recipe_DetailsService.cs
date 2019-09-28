using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Nu34life.Models;

namespace Business.Implementation
{
    public class Recipe_DetailsService : IRecipe_DetailsService
    {
        private IRecipes_DetailsRepository recipes_DetailsRepository = new
                Recipes_DetailsRepository();

        public bool Eliminar(int a, int b)
        {
            return recipes_DetailsRepository.Eliminar(a, b);
        }

        public List<Recipe_Details> Listar()
        {
            return recipes_DetailsRepository.Listar();
        }

        public Recipe_Details ListarPorId(int? id)
        {
            return recipes_DetailsRepository.ListarPorId(id);
        }

        public bool Insertar(Recipe_Details a)
        {
            return recipes_DetailsRepository.Insertar(a);
        }
        public bool Actualizar(Recipe_Details a)
        {
            return recipes_DetailsRepository.Actualizar(a);
        }

    }
}
