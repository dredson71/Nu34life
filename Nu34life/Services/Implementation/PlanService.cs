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
    public class PlanService : IPlanService
    {
        private IPlanRepository planRepository = new
                PlanRepository();

        public void setPlan(IPlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }


        public bool Eliminar(int a, int b)
        {
            return planRepository.Eliminar(a, b);
        }

        public List<Plan> Listar()
        {
            return planRepository.Listar();
        }

        public Plan ListarPorId(int? id)
        {
            return planRepository.ListarPorId(id);
        }

        public bool Insertar(Plan a)
        {
            if(a.State == null || a.State_Id==0)
            {
                return false;
            }
            else
            planRepository.Insertar(a);
            return true;
        }
        public bool Actualizar(Plan a)
        {
            return planRepository.Actualizar(a);
        }

        public List<Plan> ListarByState(State s)
        {
            List<Plan> plans = planRepository.Listar();
            for (int i = 0; i < plans.Count(); i++)
            {
                if (plans[i].State.Id != s.Id)
                {
                    plans.RemoveAt(i);
                    i -= 1;
                }


            }
            return plans;
        } 

    }
}