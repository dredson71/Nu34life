using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Business
{
    public interface IRecipeService : IService<Recipe>
    {
        List<Recipe> ListarbyFiltro(Patient p);
    }
}
