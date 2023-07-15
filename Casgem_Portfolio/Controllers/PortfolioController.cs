using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;
namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
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
        public PartialViewResult PartialFeature() //Öne çıkan kısım 
        {
            ViewBag.featuretitle = db.TblFeature.Select(x => x.FeatureTitle).FirstOrDefault(); //tek değer çekerken kullanılan method iki veri de tollist
            ViewBag.featuredescription = db.TblFeature.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImage = db.TblFeature.Select(x => x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialHareketliBolum()
        {
            var values = db.TblHareketliBolum.ToList();
            return PartialView(); //hareketli bölüm dinamik yapılacak ödev 
        }
        public PartialViewResult MyResume()
        {
            var values = db.TblREsume.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatıstıc()
        {
            ViewBag.totalservice = db.TblService.Count(); //count methodu ilgili tablonun kayıt sayısını döndürür
            ViewBag.totalmessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count(); //teşekkür mesajı sayısı
            return PartialView();
        }
        public PartialViewResult PartialWhoami()
        {

            return PartialView();
        }

        public PartialViewResult PartialServices()
        {
            ViewBag.departmentname = db.TblDeparment.ToList().FirstOrDefault();
            return PartialView();
        }
        [HttpGet]
        public FileResult Download()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(this.Server.MapPath("\\Data\\Aleyna çelik.pdf"));
            string fileName = "Aleyna çelik.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}