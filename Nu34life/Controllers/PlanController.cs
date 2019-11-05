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

        IPatientService patientService = new PatientService();
        IPlanService planService = new PlanService();
        IRecipeService recipeService = new RecipeService();
        IStateService stateService = new StateService();
        IPlan_RecipeService plan_RecipeService = new Plan_RecipeService();
        // GET: Plan


            
        public ActionResult Index()
        {
            if (TempData["State"] != null)
            {
                var st = (State)TempData["State"];
                TempData["statedata"] = st;
                TempData.Keep("State");

                var a = plan_RecipeService.ListarporPlan(st);

                Plans_Recipes vacio = new Plans_Recipes();
                ICollection<Plans_Recipes> planRecipiente = new List<Plans_Recipes>();
                planRecipiente.Add(vacio);


                if (a != null)
                {
                    
                    var plandata_aux=planService.ListarByState(st).setPlanRecipe(a);
                    TempData["Plan"] = planService.ListarByState(st);
                    TempData["stated"] = st;
                    TempData.Keep("stated");
                    TempData.Keep("Plan");
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
            TempData.Keep("State");
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            var Data = TempData["State"] as State;
            return View();
        }

        public ActionResult CreatePlan_Recipe()
        {
            return View();
        }

        public ActionResult ListaRecipe()
        {
            var Data = TempData["statedata"] as State;
        
            return PartialView(recipeService.Listar());
           
        }


        [HttpPost]
        public ActionResult CreatePlan_Recipe(Plans_Recipes m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var Data = TempData["stated"] as State;
                var plandata = (Plan)TempData["Plan"];
                TempData.Keep("Plan");
                TempData.Keep("stated");
                var state = stateService.ListarPorId(Data.GetId());

              
                var planbyservice=planService.ListarByState(Data);
                m.setPlan_Id(plandata.Id);


                var cond = plan_RecipeService.Insertar(m);
                m.setPlan(planbyservice);

                if (cond)
                {
                    TempData["State"] = state;
                    return RedirectToAction("Index");
                }
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



        [HttpPost]
        public ActionResult Create(Plan m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                
                 var st = (State)TempData["statedata"];
                TempData.Keep("statedata");
                var statetemp =stateService.ListarPorId(st.Id);


                m.setState_Id(st.Id);

                var cond = planService.Insertar(m);

                m.setState(statetemp);
                if (cond)
                {
                    TempData["stated"]= st;
                    TempData["Plan"] = m;
                    TempData.Keep("Plan");
                    TempData.Keep("stated");
                    return RedirectToAction("CreatePlan_Recipe");
                }

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