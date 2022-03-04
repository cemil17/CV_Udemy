using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Models.Entity;
using CV_Udemy.Repositories;

namespace CV_Udemy.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TBL_SocialMedia> repo = new GenericRepository<TBL_SocialMedia>();
        public ActionResult Index()
        {
            var media = repo.List();
            return View(media);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TBL_SocialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PageGet(int id)
        {
            var get = repo.Find(c => c.ID == id);
            return View(get);
        }
        [HttpPost]
        public ActionResult PageGet(TBL_SocialMedia s)
        {
            var get = repo.Find(c => c.ID == s.ID);
            get.SocialMedia = s.SocialMedia;
            get.Link = s.Link;
            get.Icon = s.Icon;
            get.State = true;
            repo.TUpdate(get);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var remove = repo.Find(c => c.ID == id);
            remove.State = false;
            repo.TUpdate(remove);
            return RedirectToAction("Index");
        }
    }
}