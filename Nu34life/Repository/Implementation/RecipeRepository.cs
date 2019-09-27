using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class RecipeRepository : IRecipeRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Recipes.ToList();
        }

        public Recipe ListarPorId(int? id)
        {

            throw new NotImplementedException();
        }

        public bool Actualizar(Recipe a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Recipe a)
        {
            var db = new Nu34lifeEntities();
            db.Recipes.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
