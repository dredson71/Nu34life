using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Business;
using Business.Implementation;

namespace Nu34life.Controllers
{
    public class AllergieController : Controller
    {
        IPatientService patientService = new PatientService();
        IIngredientService ingredientService = new IngredientService();
        IAllergyService allergyService = new AllergyService();
        Nu34lifeEntities ctx;
        public AllergieController()
        {
            ctx = new Nu34lifeEntities();
        }
        // GET: Drug
        public ActionResult Index()
        {
            using (var db = new Nu34lifeEntities())
            {
                PartialView(db.Allergies.ToList());
            }
            if (TempData["State"] != null)
            {
                var sta = (State)TempData["State"];

                var All = from p in ctx.Allergies
                             where p.Ingredient_Id == sta.Id
                             select p;

                TempData.Keep("State");
                

                return View(All.ToList());
            }
            else
            {
                return View(ctx.Allergies.ToList());
            }

        }

        public ActionResult Create()
        {

            var db = new Nu34lifeEntities();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Allergy d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var result = allergyService.Insertar(d);
                if (result)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Medicamento", ex);
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
                    Allergy n = db.Allergies.Find(id);
                    return View(n);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Allergy d)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    Allergy all = db.Allergies.Find(d);
                    all.Description = d.Description;
                    all.Ingredient_Id = d.Ingredient_Id;
                    all.Patient_Id = d.Patient_Id;

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
                Allergy i = db.Allergies.Find(id);
                return View(i);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Allergy i = db.Allergies.Find(id);
                db.Allergies.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }



        public ActionResult ListPatient()
        {
            
                return PartialView(patientService.Listar());
            
        }


        public ActionResult ListIngredient()
        {
            return PartialView(ingredientService.Listar());

        }


    }

}