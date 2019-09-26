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
    public class NutritionistService : INutritionistService
    {
        private INutritionistRepository nutritionistRepository = new
                NutritionistRepository();

        public bool Eliminar(int a, int b)
        {
            return nutritionistRepository.Eliminar(a, b);
        }

        public List<Nutritionist> Listar()
        {
            return nutritionistRepository.Listar();
        }

        public Nutritionist ListarPorId(int? id)
        {
            return nutritionistRepository.ListarPorId(id);
        }

        public bool Insertar(Nutritionist a)
        {
            return nutritionistRepository.Insertar(a);
        }
        public bool Actualizar(Nutritionist a)
        {
            return nutritionistRepository.Actualizar(a);
        }

    }
}