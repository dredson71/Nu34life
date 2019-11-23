using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Nu34life.Models.Nutritionist nutritionistModel)
        {
            using (var db = new Nu34lifeEntities())
            {
                var nutritionistDetails = db.Nutritionists.Where(x=>x.Email == nutritionistModel.Email && x.Password == nutritionistModel.Password).FirstOrDefault();
                if(nutritionistDetails == null)
                {
                    return View("Index", nutritionistModel);
                }
                else
                {
                    Session["Email"] = nutritionistDetails.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
               
        }
    }
}