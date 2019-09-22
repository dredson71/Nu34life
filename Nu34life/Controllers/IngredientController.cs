using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    return View(db.Ingredients.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ingredient i)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    db.Ingredients.Add(i);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Ingrediente", ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                try
                {
                    //Nutritionist nu = db.Nutritionists.Where(n => n.Id == id).FirstOrDefault();
                    Ingredient n = db.Ingredients.Find(id);
                    return View(n);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Ingredient i)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    Ingredient ing = db.Ingredients.Find(i.Id);
                    ing.Name = i.Name;
                    ing.Description = i.Description;
                    ing.Protein = i.Protein;
                    ing.Carbohydrates = i.Carbohydrates;
                    ing.Cholesterol = i.Cholesterol;
                    ing.Fat = i.Fat;
                    ing.Potasium = i.Potasium;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Ingredient i = db.Ingredients.Find(id);
                return View(i);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Ingredient i = db.Ingredients.Find(id);
                db.Ingredients.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}