using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class InstructionRepository : IInstrucionRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Instruction> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Instructions.ToList();

        }

        public Instruction ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Instruction a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Instruction a)
        {
            var db = new Nu34lifeEntities();
            db.Instructions.Add(a);
            db.SaveChanges();
            return true;

        }

    }
}
