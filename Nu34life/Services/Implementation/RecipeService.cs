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


        private IAllergyRepository allergyRepository =
            new AllergyRepository();

        public void setRecipeRepo(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public void setAllergyRepo(IAllergyRepository allergyRepository)
        {
            this.allergyRepository = allergyRepository;
        }

        public bool Eliminar(int a, int b)
        {
            return recipeRepository.Eliminar(a, b);
        }

        public List<Recipe> ListarbyFiltro(Patient p)
        {

            List<Recipe> recipes = recipeRepository.Listar();
            List<Allergy> allergies = allergyRepository.Listar();
            for (int i = 0; i < allergies.Count(); i++)
            {
                if (allergies[i].Patient_Id != p.Id)
                {
                    allergies.RemoveAt(i);
                    i -= 1;
                }


            }
            for (int i = 0; i < recipes.Count(); i++)
                if (recipes[i].Recipe_Details.ElementAt(i).Ingredient_Id == allergies[i].Ingredient_Id)
                {
                    recipes.RemoveAt(i);
                    i -= 1;
                }
            return recipeRepository.Listar();
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