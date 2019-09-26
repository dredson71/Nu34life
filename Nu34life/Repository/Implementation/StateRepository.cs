using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class StateRepository : IStateRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<State> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.States.ToList();
        }

        public State ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(State a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(State a)
        {
            throw new NotImplementedException();
        }

    }
}
