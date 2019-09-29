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
        int cantidadminima = 1;
        private INutritionistRepository nutritionistRepository = new
                NutritionistRepository();

        private IStateRepository stateRepository = new
               StateRepository();

        public void setNutritionist(INutritionistRepository nutritionistRepository)
        {
            this.nutritionistRepository = nutritionistRepository;
        }

        public void setState(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        public bool Eliminar(int a, int b)
        {
            return nutritionistRepository.Eliminar(a, b);
        }


        public bool actualizarEstado(Patient patient,State state,Plan plan)
        {
            if (patient.getEmail().Equals(""))
                return false;
            if (plan.getPlanRecipe().Count == 0)
                return false;
            if (!cantidadPlatosPermi(plan))
                return false;

             stateRepository.Insertar(state);
            return true;
        }


        public List<Nutritionist> Listar()
        {
            return nutritionistRepository.Listar();
        }

        public Nutritionist ListarPorId(int? id)
        {
            return nutritionistRepository.ListarPorId(id);
        }
        public bool letModificarPerfil(Nutritionist n,String password)

        {
            List<Nutritionist> nutritionists = nutritionistRepository.Listar();
            for (int i = 0; i < nutritionists.Count(); i++)
            {
                if (nutritionists[i].Id == n.Id)
                {
                    if (nutritionists[i].Password == password)
                    {
                        if (nutritionists[i].Email == n.Email)
                        {
                            nutritionistRepository.Actualizar(n);
                            return true;
                        }
                    }
                }
            }
            return false;
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
            List<Nutritionist> nutritionists = nutritionistRepository.Listar();
            for (int i = 0; i < nutritionists.Count(); i++)
            {
                    if (nutritionists[i].Email != a.Email)
                    {
                        return false;
                    }
            }
            nutritionistRepository.Actualizar(a);
            return true;
        }


        public bool cantidadPlatosPermi(Plan plan)
        {
            if (plan.getPlanRecipe().Count < cantidadminima)
                return false;
            return true;
        }

    }
}