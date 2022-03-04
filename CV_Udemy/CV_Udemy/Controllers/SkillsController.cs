using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;
using PagedList;
using PagedList.Mvc;

namespace CV_Udemy.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository<TBL_Skills> repo = new GenericRepository<TBL_Skills>();
        public ActionResult Index(int number = 1)
        {
            var talent = repo.List().ToPagedList(number, 9);
            return View(talent);
        }
        [HttpGet]
        public ActionResult NewSkills()
        {
            return View();

        }
        [HttpPost]
        public ActionResult NewSkills(TBL_Skills s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveSkills(int id)
        {
            var skills = repo.Find(x => x.ID == id);
            repo.TDelete(skills);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkills(int id)
        {
            var skills = repo.Find(x => x.ID == id);
            return View(skills);
        }
        [HttpPost]
        public ActionResult UpdateSkills(TBL_Skills s)
        {
            var t = repo.Find(x => x.ID == s.ID);
            t.Skills = s.Skills;
            t.Degree = s.Degree;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}