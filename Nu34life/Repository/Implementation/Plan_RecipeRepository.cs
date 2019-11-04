using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;
namespace Data.Implementacion
{
    public class Plan_RecipeRepository : IPlan_RecipeRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Plans_Recipes> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Plans_Recipes.ToList();
        }

        public Plans_Recipes ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Plans_Recipes a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Plans_Recipes a)
        {
            var db = new Nu34lifeEntities();
            db.Plans_Recipes.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
