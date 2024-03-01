using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;
namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            ViewBag.address = db.TblAdress;
            return PartialView();
        }
        [HttpPost]
        public JsonResult Add(TblContact p)
        {
            if (ModelState.IsValid)
            {
                p.SendMessageDate = DateTime.Now;
                p.IsRead = false;
                var value = db.TblContact.Add(p);
                db.SaveChanges();
                return Json("OK"); // Başarılı bir şekilde eklendiğinde "OK" yanıtı döndürülür
            }
            // Eğer model geçersizse, hata mesajlarıyla birlikte hata yanıtı döndürülür
            return Json("Model validation failed.");
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialAddress()
        {
            var values = db.TblAdress.ToList();
           
            return PartialView(values);
        }
        public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.Where(x => x.Status == true).ToList();

            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.ServiceCount = db.TblService.Count();
            return PartialView();
        }
        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
    }
}