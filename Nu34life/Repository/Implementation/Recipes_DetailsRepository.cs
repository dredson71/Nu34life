using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;
namespace Data.Implementacion
{
    public class Recipes_DetailsRepository : IRecipes_DetailsRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Recipe_Details> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Recipe_Details.ToList();
        }

        public Recipe_Details ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Recipe_Details a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Recipe_Details a)
        {
            var db = new Nu34lifeEntities();
            db.Recipe_Details.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}


