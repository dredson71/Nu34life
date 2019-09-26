using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IService<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(int a, int b);
        List<T> Listar();
        T ListarPorId(int? id);
    }
}
