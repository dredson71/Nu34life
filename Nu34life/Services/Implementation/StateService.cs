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

        public List<State> ListByPatient(Patient p)
        {
            List<State> states = stateRepository.Listar();
            for (int i = 0; i < states.Count(); i++)
            {
                if (states[i].Patient.Id != p.Id) { 
                    states.RemoveAt(i);
                    i -= 1;
            }
                    

            }
            return states;
        }

        public State ListarPorId(int? id)
        {
            return stateRepository.ListarPorId(id);
        }

        public bool Insertar(State a)
        {
            if (a.Description.Count() < 75 && a.Generated_day < a.Expiration)
                return stateRepository.Insertar(a);
            else return false;

        }
        public bool Actualizar(State a)
        {
            return stateRepository.Actualizar(a);
        }

    }
}