using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class FeatureController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Feature
        public ActionResult FeatureList()
        {
            ViewBag.featureCount = db.TblFeature.Count();
            var values = db.TblFeature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            var countFeature = db.TblFeature.Count();
            if (countFeature > 0)
            {
                ViewBag.countFeature = countFeature;

            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(TblFeature p)
        {
            var countFeature = db.TblFeature.Count();
            if (countFeature > 0)
            {
                return RedirectToAction("FeatureList");
            }
            else
            {
                db.TblFeature.Add(p);
                db.SaveChanges();
            }
            return RedirectToAction("FeatureList");

        }

        public ActionResult DeleteFeature(int id)
        {
            var values = db.TblFeature.Find(id);
            db.TblFeature.Remove(values);
            db.SaveChanges();

            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = db.TblFeature.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p)
        {
            var values = db.TblFeature.Find(p.FeatureID);
            values.HeaderTitle = p.HeaderTitle;
            values.HeaderDescription = p.HeaderDescription;
            db.SaveChanges();

            return RedirectToAction("FeatureList");
        }
    }
}