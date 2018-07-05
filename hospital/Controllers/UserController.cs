using hospital.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hospital.Models;

namespace hospital.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Database1Entities3 db;

        public UserController()
        {
            db = new Database1Entities3();

        }
        public ActionResult Index()
        {
            var users = db.User.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.Type.ToList(), "Id", "TypeName");
            //ViewBag.StatusId = new SelectList(db.Status.ToList(), "Id", "StatusName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = Guid.NewGuid();

            db.User.Add(user);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {

            User user = db.User.Find(Id);

            ViewBag.TypeId = new SelectList(db.Type.ToList(), "Id", "TypeName");
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}