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
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository ingredientRepository = new
                IngredientRepository();

        public bool Eliminar(int a, int b)
        {
            return ingredientRepository.Eliminar(a, b);
        }

        public List<Ingredient> Listar()
        {
            return ingredientRepository.Listar();
        }

        public Ingredient ListarPorId(int? id)
        {
            return ingredientRepository.ListarPorId(id);
        }

        public bool Insertar(Ingredient a)
        {
            return ingredientRepository.Insertar(a);
        }
        public bool Actualizar(Ingredient a)
        {
            return ingredientRepository.Actualizar(a);
        }

    }
}