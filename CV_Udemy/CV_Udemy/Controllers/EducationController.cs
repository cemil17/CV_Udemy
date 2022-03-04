using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;

namespace CV_Udemy.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TBL_Education> repo = new GenericRepository<TBL_Education>();
        public ActionResult Index()
        {
            var edu = repo.List();
            return View(edu);
        }

        [HttpGet]
        public ActionResult EducationNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationNew(TBL_Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationNew");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        public ActionResult EducationRemove(int id)
        {
            var edu = repo.Find(x => x.ID == id);
            repo.TDelete(edu);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationGet(int id)
        {
            var edu = repo.Find(x => x.ID == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult EducationGet(TBL_Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationGet");
            }
            var edu = repo.Find(x => x.ID == e.ID);
            edu.Title = e.Title;
            edu.Subtitle = e.Subtitle;
            edu.Subtitle2 = e.Subtitle2;
            edu.GPA = e.GPA;
            edu.DateTime = e.DateTime;

            repo.TUpdate(edu);
            return RedirectToAction("Index");
        }
    }
}