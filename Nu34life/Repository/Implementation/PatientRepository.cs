using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class PatientRepository : IPatientRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Patient> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Patients.ToList();
        }

        public Patient ListarPorId(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(Patient a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Patient a)
        {
            throw new NotImplementedException();
        }

    }
}
