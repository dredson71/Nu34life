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
    public class PlanController : Controller
    {
        Nu34lifeEntities ctx;
        public PlanController()
        {
            ctx = new Nu34lifeEntities();
        }

        IPlanService planService = new PlanService();
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
                TempData.Keep("State");



                return View(planService.ListarByState(st));
            }
            else
            {
                return View(planService.Listar());
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