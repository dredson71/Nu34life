using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class AllergyRepository : IAllergyRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Allergy> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Allergies.ToList();
        }

        public Allergy ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Allergy a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Allergy a)
        {
            var db = new Nu34lifeEntities();
            db.Allergies.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
