using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            
            var user = db. TblAdmin.FirstOrDefault(x => x.Admina == p.Admina && x.Sifre == p.Sifre);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Admina, false);
                Session["Admina"] = user.Admina.ToString();
                return RedirectToAction("Index", "Abouts");
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }
    }
}