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
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository recipeRepository = new
                RecipeRepository();

        public bool Eliminar(int a, int b)
        {
            return recipeRepository.Eliminar(a, b);
        }

        public List<Recipe> Listar()
        {
            return recipeRepository.Listar();
        }

        public Recipe ListarPorId(int? id)
        {
            return recipeRepository.ListarPorId(id);
        }

        public bool Insertar(Recipe a)
        {
            return recipeRepository.Insertar(a);
        }
        public bool Actualizar(Recipe a)
        {
            return recipeRepository.Actualizar(a);
        }

    }
}