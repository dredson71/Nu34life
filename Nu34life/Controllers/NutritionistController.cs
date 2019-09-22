using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class NutritionistController : Controller
    {
        Nu34lifeEntities ctx;
        public NutritionistController()
        {
            ctx = new Nu34lifeEntities();
        }
        // GET: Drug
        public ActionResult IndexTesting()
        {
            using (var db = new Nu34lifeEntities())
            {
                PartialView(db.Nutritionists.ToList());
            }
            if (TempData["State"] != null)
            {
                var sta = (State)TempData["State"];

                var Nutri = from p in ctx.Nutritionists
                          where p.Id == sta.Id
                          select p;

                TempData.Keep("State");


                return View(Nutri.ToList());
            }
            else
            {
                return View(ctx.Nutritionists.ToList());
            }

        }

        [HttpPost]
        public ActionResult IndexTesting(int id = 0)
        {
            var Data = TempData["State"] as State;


            return RedirectToAction("IndexTesting");
        }
        // GET: Nutritionist
        public ActionResult Index()
        {
            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    return View(db.Nutritionists.ToList());
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
        public ActionResult Create(Nutritionist n)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    db.Nutritionists.Add(n);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Nutricionista", ex);
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
                    Nutritionist n = db.Nutritionists.Find(id);
                    return View(n);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }

        [HttpPost]
        public ActionResult Edit(Nutritionist n)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    Nutritionist nu = db.Nutritionists.Find(n.Id);
                    nu.Name = n.Name;
                    nu.LastName = n.LastName;
                    nu.Password = n.Password;
                    nu.Email = n.Email;
                    nu.Birthday = n.Birthday;
                    nu.Validate = n.Validate;

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
                Nutritionist n = db.Nutritionists.Find(id);
                return View(n);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Nutritionist n = db.Nutritionists.Find(id);
                db.Nutritionists.Remove(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}