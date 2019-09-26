using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;
namespace Data.Implementacion
{
    public class PlanRepository : IPlanRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Plan> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Plans.ToList();
        }

        public Plan ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Plan a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Plan a)
        {
            throw new NotImplementedException();
        }

    }
}
