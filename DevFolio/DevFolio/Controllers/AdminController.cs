using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class AdminController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult AdminList()
        {
            var values = db.TblAdmin.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(TblAdmin p)
        {
            db.TblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = db.TblAdmin.Find(id);
            db.TblAdmin.Remove(value);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = db.TblAdmin.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin p)
        {
            var value = db.TblAdmin.Find(p.AdminID);
            value.Username = p.Username;
            value.Password = p.Password;
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }
    }
}