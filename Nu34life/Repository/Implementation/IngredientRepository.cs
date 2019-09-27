﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nu34life.Models;

namespace Data.Implementacion
{
    public class IngredientRepository : IIngredientRepository
    {
        public bool Eliminar(int id, int b)
        {
            throw new NotImplementedException();
        }

        public List<Ingredient> Listar()
        {
            var db = new Nu34lifeEntities();
            return db.Ingredients.ToList();
        }

        public Ingredient ListarPorId(int? id)
        {
            throw new NotImplementedException();

        }

        public bool Actualizar(Ingredient a)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Ingredient a)
        {
            var db = new Nu34lifeEntities();
            db.Ingredients.Add(a);
            db.SaveChanges();
            return true;
        }

    }
}
