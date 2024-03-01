using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class AdressController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AdressList()
        {
            ViewBag.adresscount = db.TblAdress.Count();
            var values = db.TblAdress.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAdress()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateAdress(TblAdress p)
        {
            db.TblAdress.Add(p);
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        public ActionResult DeleteAdress(int id)
        {
            var value = db.TblAdress.Find(id);
            db.TblAdress.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
        [HttpGet]
        public ActionResult UpdateAdress(int id)
        {
            var value = db.TblAdress.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdress(TblAdress p)
        {
            var value = db.TblAdress.Find(p.AdressID);
            value.Description =p.Description;
            value.Email =p.Email;
            value.Location =p.Location;
            value.PhoneNumber = p.PhoneNumber;
            db.SaveChanges();
            return RedirectToAction("AdressList");
        }
    }
}