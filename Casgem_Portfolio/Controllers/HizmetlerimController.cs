using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Casgem_Portfolio.Controllers
{
    public class HizmetlerimController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHizmet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHizmet(TblService p)
        {
            db.TblService.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ServicesUpdate(int id)
        {
            var values = db.TblService.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult ServicesUpdate(TblService p)
        {
            var values = db.TblService.Find(p.ServiceID);
            values.ServiceTitle = p.ServiceTitle;
            values.ServiceIcon = p.ServiceIcon;
            values.ServiceNumber = p.ServiceNumber;
            values.ServiceContent = p.ServiceContent;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
