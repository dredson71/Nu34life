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
    public class StateService : IStateService
    {
        private IStateRepository stateRepository = new
                StateRepository();

        public bool Eliminar(int a, int b)
        {
            return stateRepository.Eliminar(a, b);
        }

        public List<State> Listar()
        {
            return stateRepository.Listar();
        }

        public State ListarPorId(int? id)
        {
            return stateRepository.ListarPorId(id);
        }

        public bool Insertar(State a)
        {
            return stateRepository.Insertar(a);
        }
        public bool Actualizar(State a)
        {
            return stateRepository.Actualizar(a);
        }

    }
}