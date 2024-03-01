using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
//using PagedList;
//using PagedList.Mvc;

namespace DevFolio.Controllers
{
    public class ContactController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        // GET: Contact

        //public ActionResult MessageList(int page = 1)
        public ActionResult MessageList()
        {
            //var values = db.TblContact.ToList().ToPagedList(page,10);
            var values = db.TblContact.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var values = db.TblContact.Find(id);
            values.IsRead = true;
            db.SaveChanges();
            return View(values);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {

            p.IsRead = false;
            p.SendMessageDate = DateTime.Now;
            db.TblContact.Add(p);

            db.SaveChanges();
            return RedirectToAction("Index", "Default");

        }
        [AllowAnonymous]
        public JsonResult Add(TblContact p)
        {

            return Json(SendMessage(p), JsonRequestBehavior.AllowGet);
        }


    }
}