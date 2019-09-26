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
    public class InstructionService : IInstrucionService
    {
        private IInstrucionRepository instructionRepository = new
                InstructionRepository();

        public bool Eliminar(int a, int b)
        {
            return instructionRepository.Eliminar(a, b);
        }

        public List<Instruction> Listar()
        {
            return instructionRepository.Listar();
        }

        public Instruction ListarPorId(int? id)
        {
            return instructionRepository.ListarPorId(id);
        }

        public bool Insertar(Instruction a)
        {
            return instructionRepository.Insertar(a);
        }
        public bool Actualizar(Instruction a)
        {
            return instructionRepository.Actualizar(a);
        }

    }
}