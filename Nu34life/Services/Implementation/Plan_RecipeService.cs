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
    public class Plan_RecipeService : IPlan_RecipeService
    {
        private IPlan_RecipeRepository plan_RecipeRepository = new
           Plan_RecipeRepository();

        private IPlanService PlanService = new PlanService();

        public bool Eliminar(int a, int b)
        {
            return plan_RecipeRepository.Eliminar(a, b);
        }

        public List<Plans_Recipes> Listar()
        {
            return plan_RecipeRepository.Listar();
        }

        public Plans_Recipes ListarPorId(int? id)
        {
            return plan_RecipeRepository.ListarPorId(id);
        }

        public bool Insertar(Plans_Recipes a)
        {
            return plan_RecipeRepository.Insertar(a);
        }
        public bool Actualizar(Plans_Recipes a)
        {
            return plan_RecipeRepository.Actualizar(a);
        }



        public List<Plans_Recipes> ListarporPlan(State s)
        {
            List<Plans_Recipes> planesbyRecipe = plan_RecipeRepository.Listar();
            Plan plan=PlanService.ListarByState(s);

            if (plan != null)
            {
                for (int i = 0; i < planesbyRecipe.Count(); i++)
                {
                    if (planesbyRecipe.ElementAt(i).Plan_Id != plan.Id)
                    {
                        planesbyRecipe.RemoveAt(i);
                        i -= 1;
                    }
                }


                return planesbyRecipe;
            }



            else return null;
        }

    }
}