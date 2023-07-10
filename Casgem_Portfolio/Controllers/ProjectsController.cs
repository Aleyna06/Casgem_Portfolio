using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;
namespace Casgem_Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }//sayfa çalışınca açılacak

        [HttpPost]
        public ActionResult AddProject(TblProjects p)
        {
            db.TblProjects.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }  //sayfada butona tıklayınca çalışacak
        public ActionResult DeleteProject(int id)
        {

            var value = db.TblProjects.Find(id); //Birincil anahtarın olduğu sütunu buluyo 
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProjects.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProjects p)
        {
            var value = db.TblProjects.Find(p.ProjectID);
            value.ProjectName = p.ProjectName;
            value.ProjectType = p.ProjectType;
            value.ProjectDescription = p.ProjectDescription;
            value.TechnologiesUsed = p.TechnologiesUsed;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}