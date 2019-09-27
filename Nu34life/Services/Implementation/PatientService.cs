using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementacion;
using Nu34life.Models;

namespace Business.Implementation
{
    public class PatientService : IPatientService
    {
        private IPatientRepository patientRepository = new
                PatientRepository();

        public bool Eliminar(int a, int b)
        {
            return patientRepository.Eliminar(a, b);
        }

        public List<Patient> Listar()
        {
            return patientRepository.Listar();
        }

        public Patient ListarPorId(int? id)
        {
            return patientRepository.ListarPorId(id);
        }

        public bool Insertar(Patient a)
        {
            List<Patient> patient = patientRepository.Listar();
            for (int i = 0; i < patient.Count(); i++)
            {
                if (patient[i].Email == a.Email)
                {
                    return false;
                }


            } 
         
            return patientRepository.Insertar(a);
        }
        public bool Actualizar(Patient a)
        {
            return patientRepository.Actualizar(a);
        }

    }
}