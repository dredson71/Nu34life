using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;


namespace Data
{
    public interface IRepository<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(int id, int b);
        List<T> Listar();
        T ListarPorId(int? id);
    }
}
