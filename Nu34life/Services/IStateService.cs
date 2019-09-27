using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Business
{
    public interface IStateService : IService<State>
    {
        List<State> ListByPatient(Patient P);

    }
}
