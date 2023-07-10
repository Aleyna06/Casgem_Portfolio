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
        public ActionResult AddService()
        {
            return View();
        }
    }
}