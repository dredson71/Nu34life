﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;
namespace Business
{
    public interface IPlan_RecipeService : IService<Plans_Recipes>
    {
         List<Plans_Recipes> ListarporPlan(State s);
    }
}