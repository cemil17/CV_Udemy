using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;

namespace CV_Udemy.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TBL_Admin> repo = new GenericRepository<TBL_Admin>();
        public ActionResult Index()
        {
            var admin = repo.List();
            return View(admin);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(TBL_Admin a)
        {
            repo.TAdd(a);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Remove(int id)
        {
            TBL_Admin e = repo.Find(x => x.ID == id);
            repo.TDelete(e);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult AdminGet(int id)
        {
            TBL_Admin e = repo.Find(x => x.ID == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult AdminGet(TBL_Admin p)
        {
            TBL_Admin e = repo.Find(x => x.ID == p.ID);
            e.ID = p.ID;
            e.Username = p.Username;
            e.Password = p.Password;
            repo.TUpdate(e);
            return RedirectToAction("Index", "Admin");
        }
    }
}