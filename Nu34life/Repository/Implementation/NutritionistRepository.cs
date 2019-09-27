using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class NutritionistRepository : INutritionistRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }
      

        public List<Nutritionist> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Nutritionists.ToList();
        }

        public Nutritionist ListarPorId(int? id)
        {
        throw new NotImplementedException();
    }

        public bool Actualizar(Nutritionist a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Nutritionist a)
        {
            var db = new Nu34lifeEntities();
            db.Nutritionists.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
