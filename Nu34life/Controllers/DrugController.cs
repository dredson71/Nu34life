using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class DrugController : Controller
    {
        // GET: Drug
        public ActionResult Index()
        {
            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    return View(db.Drugs.ToList());
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
        public ActionResult Create(Drug d)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    db.Drugs.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
                    Drug n = db.Drugs.Find(id);
                    return View(n);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Drug d)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    Drug dru = db.Drugs.Find(d.Id);
                    dru.Name = d.Name;
                    dru.Description = d.Description;

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
                Drug i = db.Drugs.Find(id);
                return View(i);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Drug i = db.Drugs.Find(id);
                db.Drugs.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

}