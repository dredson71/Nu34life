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
    public class PatientController : Controller
    {
        IPatientService patientService = new PatientService();
        INutritionistService nutritionistService = new NutritionistService();


        public PatientController()
        {
           
        }

        public void changeService(IPatientService patientService,
                      INutritionistService nutritionistService)
        {
            this.patientService = patientService;
            this.nutritionistService = nutritionistService;
        }
        // GET: Recipe
        public ActionResult Index()
        {
            try
            {
                return View(patientService.Listar());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Create()
        {
            var db = new Nu34lifeEntities();
            ViewBag.nutritionist = nutritionistService.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patient r)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                
                    ViewBag.nutritionist = nutritionistService.Listar();
                var result = patientService.Insertar(r);
                if (result)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Create");
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar la receta", ex);
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
                    Patient n = db.Patients.Find(id);
                    return View(n);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Recipe r)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    Patient re = db.Patients.Find(r.Id);
                    re.Name = r.Name;


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
                Patient i = db.Patients.Find(id);
                return View(i);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Patient i = db.Patients.Find(id);
                db.Patients.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult ListaNutritionist()
        {
            using (var db = new Nu34lifeEntities())
            {
                return PartialView(db.Nutritionists.ToList());
            }
        }

        public ActionResult ListaPatient()
        {
            using (var db = new Nu34lifeEntities())
            {
                return PartialView(db.Patients.ToList());
            }
        }

        public ActionResult InsertState()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InsertState(Patient p)
        {
            TempData["Patient"] = p;
            return RedirectToAction("Index", "State");
        }

    }
}