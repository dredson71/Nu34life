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
    public class StateController : Controller
    {
        IStateService stateService = new StateService();

        Nu34lifeEntities ctx;
        public StateController()
        {
            ctx = new Nu34lifeEntities();
        }

        [HttpPost]
        public ActionResult Index(int id = 0)
        {
            var Data = TempData["Patient"] as Patient;


            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
         
            if (TempData["Patient"] != null)
            {
                var Cat = (Patient)TempData["Patient"];
                TempData.Keep("Patient");

                return View(stateService.ListByPatient(Cat));
            }
            else
            {
                return View(stateService.Listar());
            }
        }

        public ActionResult SearchPlan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchPlan(State p)
        {
            TempData["State"] = p;
            return RedirectToAction("Index", "Plan");
        }

        public ActionResult ListaState()
        {
            using (var db = new Nu34lifeEntities())
            {
                return PartialView(db.States.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(State n)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    var Cat = (Patient)TempData["Patient"];
                    n.setPatient_ID (Cat.Id);
                    n.setNutritionist_ID(1);

                    var cond=stateService.Insertar(n);

                    if (cond)
                        return RedirectToAction("Index");

                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Estado", ex);
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
                    State s = db.States.Find(id);
                    return View(s);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }

        


        [HttpPost]
        public ActionResult Edit(State s)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                using (var db = new Nu34lifeEntities())
                {
                    State st = db.States.Find(s.Id);
                    st.Nutritionist_Id = s.Nutritionist_Id;
                    st.Patient_Id = s.Patient_Id;
                    st.Description = s.Description;
                    st.Weighr = s.Weighr;
                    st.Height = s.Height;
                    st.Glucose = s.Glucose;
                    st.Affiliate = s.Affiliate;
                    st.Generated_day = s.Generated_day;
                    st.Expiration = s.Expiration;

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
                State s = db.States.Find(id);
                return View(s);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                State s = db.States.Find(id);
                db.States.Remove(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}