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

        public void setNutritionist(INutritionistRepository nutritionistRepository)
        {
            this.nutritionistRepository = nutritionistRepository;
        }

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
            List<Nutritionist> nutritionists = nutritionistRepository.Listar();
            for (int i = 0; i < nutritionists.Count(); i++)
            {
                if (nutritionists[i].Email == a.Email)
                {
                    return false;
                }


            }

            nutritionistRepository.Insertar(a);
            return true;
        }
        public bool Actualizar(Nutritionist a)
        {
            return nutritionistRepository.Actualizar(a);
        }

    }
}