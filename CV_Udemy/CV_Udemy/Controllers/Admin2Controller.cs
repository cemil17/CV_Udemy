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
    public class Admin2Controller : Controller
    {
        // GET: Admin2
        CV_SiteEntities entities = new CV_SiteEntities();
        GenericRepository<TBL_TodoList> repo = new GenericRepository<TBL_TodoList>();
        public ActionResult Index(int number = 1)
        {
            //var show = repo.List();

            var max1 = entities.TBL_Certificate.Count();

            var max2 = entities.TBL_Skills.Count();

            var max3 = entities.TBL_SocialMedia.Where(x => x.State == true).Count();

            var max4 = entities.TBL_Contact.Count();

            ViewBag.m1 = max1;
            ViewBag.m2 = max2;
            ViewBag.m3 = max3;
            ViewBag.m4 = max4;

            var todolist = entities.TBL_TodoList.OrderByDescending(x => x.ID).ToPagedList(number, 4);

            return View(todolist);
        }

        public ActionResult RTodo(int id)
        {
            var remove = repo.Find(x => x.ID == id);
            remove.Situation = false;
            repo.TUpdate(remove);
            return RedirectToAction("Index", "Admin2");
        }
        [HttpGet]
        public ActionResult ATodo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ATodo(TBL_TodoList t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index", "Admin2");
        }
       
        [HttpPost]
        public ActionResult UTodo(TBL_TodoList td)
        {
            var update = repo.Find(x => x.ID == td.ID);
            update.Description = td.Description;
            update.Situation = true;
            repo.TUpdate(update);
            return RedirectToAction("Index", "Admin2");
        }
        [HttpGet]
        public ActionResult UTodo(int id)
        {
            var update = repo.Find(x => x.ID == id);
            return View(update);
        }
    }
}