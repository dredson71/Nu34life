using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class PlanController : Controller
    {
        Nu34lifeEntities ctx;
        public PlanController()
        {
            ctx = new Nu34lifeEntities();
        }
        // GET: Plan
        public ActionResult Index()
        {
            using (var db = new Nu34lifeEntities())
            {
                PartialView(db.Plans.ToList());
            }
            if (TempData["State"] != null)
            {
                var st = (State)TempData["State"];

                var plan = from p in ctx.Plans
                             where p.State_Id == st.Id
                             select p;

                TempData.Keep("State");



                return View(plan.ToList());
            }
            else
            {
                return View(ctx.Plans.ToList());
            }
        }


        [HttpPost]
        public ActionResult Index(int id = 0)
        {
            var Data = TempData["State"] as State;


            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Plan m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    db.Plans.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar la membresia", ex);
                return View();
            }
        }


     
    }
}