using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class AboutController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AboutList()
        {
            ViewBag.aboutCount = db.TblAbout.Count();
            var values = db.TblAbout.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(TblAbout p)
        {
            db.TblAbout.Add(p);
            db.SaveChanges();

            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
           var value= db.TblAbout.Find(id);
            db.TblAbout.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
       [HttpGet]
       public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var value = db.TblAbout.Find(p.AboutID);
            value.Description = p.Description;
            db.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}