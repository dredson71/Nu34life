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
            return planRepository.Insertar(a);
        }
        public bool Actualizar(Plan a)
        {
            return planRepository.Actualizar(a);
        }

    }
}