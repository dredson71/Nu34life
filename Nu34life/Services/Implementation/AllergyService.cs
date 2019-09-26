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
    public class AllergyService : IAllergyService
    {
        private IAllergyRepository allergyRepository = new
                AllergyRepository();

        public bool Eliminar(int a, int b)
        {
            return allergyRepository.Eliminar(a, b);
        }

        public List<Allergy> Listar()
        {
            return allergyRepository.Listar();
        }

        public Allergy ListarPorId(int? id)
        {
            return allergyRepository.ListarPorId(id);
        }

        public bool Insertar(Allergy a)
        {
            return allergyRepository.Insertar(a);
        }
        public bool Actualizar(Allergy a)
        {
            return allergyRepository.Actualizar(a);
        }

    }
}