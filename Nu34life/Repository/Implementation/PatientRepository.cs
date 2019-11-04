﻿using System;
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

            var db = new Nu34lifeEntities();
            return db.Patients.Find(id);
        }

        public bool Actualizar(Patient a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Patient a)
        {
            var db = new Nu34lifeEntities();
            db.Patients.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
