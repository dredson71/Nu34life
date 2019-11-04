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
        IPlan_RecipeService plan_RecipeService = new Plan_RecipeService();
        // GET: Plan
        public ActionResult Index()
        {
            if (TempData["State"] != null)
            {
                var st = (State)TempData["State"];
                TempData.Keep("State");

                var a = plan_RecipeService.ListarporPlan(st);

                

                Plans_Recipes vacio = new Plans_Recipes();
                ICollection<Plans_Recipes> planRecipiente = new List<Plans_Recipes>();
                planRecipiente.Add(vacio);


                if (a != null)
                {
                    planService.ListarByState(st).setPlanRecipe(a);
                    return View(planService.ListarByState(st).getPlanRecipe());
                }
                else
                {
                    return View(planRecipiente);
                }
                
            }
            else
            {
                return View(plan_RecipeService.Listar());
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
                
                 var st = (State)TempData["State"];

                m.setState(st);
                m.setState_Id(st.Id);

                var cond = planService.Insertar(m);

                if (cond)
                    return RedirectToAction("Index");

                else
                {
                    return View();
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