using hospital.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hospital.Models;




namespace hospital.Controllers
{
    public class SickController : Controller
    {

        Database1Entities3 db;

        public SickController()
        {
            db = new Database1Entities3();
            
        }


        public ActionResult Index()
        {
            var sicks = db.Sick.ToList();
            return View(sicks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.SexId = new SelectList(db.Sex.ToList(), "Id", "SexName");
            ViewBag.StatusId = new SelectList(db.Status.ToList(), "Id", "StatusName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sick sick)
        {
            sick.Id =  Guid.NewGuid();

            db.Sick.Add(sick);

            db.SaveChanges();

            return RedirectToAction( "Index" );
        }

        public ActionResult Edit(Guid Id)
        {

            Sick sick = db.Sick.Find(Id);

            ViewBag.SexId = new SelectList(db.Sex.ToList(), "Id", "SexName");
            ViewBag.StatusId = new SelectList(db.Status.ToList(), "Id", "StatusName");

            return View(sick);
        }
        [HttpPost]
        public ActionResult Edit(Sick sick)
        {
            db.Entry(sick).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(Guid Id)
        {
            Sick entity = db.Sick.Find(Id);
            return View(entity);
        }
       
        public ActionResult DetailViewBagResult(Guid Id)
        {
            Sick entity = db.Sick.Find(Id);
            ViewBag.SicknessName = db.Visit.Where(x => x.SickId == Id).ToList();
            //ViewBag.MdicineName = db.Visit.Where(x => x.UserId == Id).ToList();
            //Visit model = new Visit();
            //model.Sick entity = db.Sick.Find(Id);
            //model.visits = db.Visit.Where(x => x.s)

            return View(entity);
        }
        
    }
}