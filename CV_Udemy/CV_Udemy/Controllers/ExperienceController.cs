using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Repositories;
using CV_Udemy.Models.Entity;

namespace CV_Udemy.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var experience = repo.List();
            return View(experience);
        }
        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(TBL_Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View("ExperienceAdd");
            }
            repo.TAdd(experience);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceRemove(int id)
        {
            TBL_Experience e = repo.Find(x => x.ID == id);
            repo.TDelete(e);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult ExperienceGet(int id)
        {
            TBL_Experience e = repo.Find(x => x.ID == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult ExperienceGet(TBL_Experience p)
        {
            TBL_Experience e = repo.Find(x => x.ID == p.ID);
            e.ID = p.ID;
            e.Title = p.Title;
            e.DateTime = p.DateTime;
            e.Description = p.Description;

            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}