using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Udemy.Repositories;
using CV_Udemy.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace CV_Udemy.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        GenericRepository<TBL_Hobby> repo = new GenericRepository<TBL_Hobby>();
        public ActionResult Index(int number = 1)
        {
            var hobby = repo.List().ToPagedList(number, 9);
            return View(hobby);
        }
        [HttpGet]
        public ActionResult NewHobby()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewHobby(TBL_Hobby h)
        {
            if (!ModelState.IsValid)
            {
                return View("NewHobby");
            }
            repo.TAdd(h);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveHobby(int id)
        {
            var hobby = repo.Find(c => c.ID == id);
            repo.TDelete(hobby);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var hobby = repo.Find(x => x.ID == id);
            return View(hobby);
        }
        [HttpPost]
        public ActionResult UpdateHobby(TBL_Hobby h)
        {
            var hobby = repo.Find(c => c.ID == h.ID);
            hobby.Description = h.Description;
            repo.TUpdate(hobby);
            return RedirectToAction("Index");
        }
    }
}