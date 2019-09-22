using Nu34life.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nu34life.Controllers
{
    public class InstructionController : Controller
    {
        // GET: Instruction
        public ActionResult Index()
        {
            try
            {
                using (var db = new Nu34lifeEntities())
                {
                    var instructions = db.Instructions.Include(i => i.Recipe);
                    return View( instructions.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                using (var db = new Nu34lifeEntities())
                {
                    Instruction i = db.Instructions.Find(id);
                    return View(i);
                }
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Nu34lifeEntities())
            {
                Instruction i = db.Instructions.Find(id);
                db.Instructions.Remove(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }


}