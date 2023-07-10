using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ReferanceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblReferance.ToList();
            return View(values);


        }
        [HttpGet]
        public ActionResult AddReferance()
        {
            return View();
        }//sayfa çalışınca açılacak

        [HttpPost]
        public ActionResult AddReferance(TblReferance p)
        {
            db.TblReferance.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  //sayfada butona tıklayınca çalışacak
        public ActionResult DeleteReferance(int id)
        {

            var value = db.TblReferance.Find(id); //Birincil anahtarın olduğu sütunu buluyo 
            db.TblReferance.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateReferance(int id)
        {
            var value = db.TblReferance.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReferance(TblReferance p)
        {
            var value = db.TblReferance.Find(p.ReferansID);
            value.ReferanceSirket = p.ReferanceSirket;
            value.ReferancePozisyon = p.ReferancePozisyon;
            value.ReferanceEposta = p.ReferanceEposta;
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}