using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;
namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities(); //db isimli nesne üretttim 
        // GET: Service
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }//sayfa çalışınca açılacak

        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  //sayfada butona tıklayınca çalışacak
        public ActionResult DeleteService(int id)
        {
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceID);
            value.ServiceTitle = p.ServiceTitle;
            value.ServiceIcon = p.ServiceIcon;
            value.ServiceNumber = p.ServiceNumber;
            value.ServiceContent = p.ServiceContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}