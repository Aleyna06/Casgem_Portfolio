using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;
namespace Casgem_Portfolio.Controllers
{
    public class StatısticController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();

            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(y => y.EmployeName).FirstOrDefault();

            ViewBag.TotalCityCount = db.TblEmployee.Select(x => x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmplooyeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.countSoftwareDepartment = db.TblEmployee.Where(x => x.EmployeeDepartment == db.TblDeparment.Where(z => z.DeparmentName == "Yazılım").Select(y => y.DeparmentID).FirstOrDefault()).Count();

            //şehri adana veya adan olanların toplam maaşı 
            ViewBag.cityAnkaraOrAdanaSumSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Bursa" || x.EmployeeCity == "Ankara").Sum(y => y.EmployeeSalary);

            //Ankarada yazılım departmnanında çalışan personellerin toplam maaşı 
            ViewBag.cityAnkarafromSoftwareSumSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Ankara" && x.EmployeeDepartment == db.TblDeparment.Where(z => z.DeparmentName == "Yazılım").Select(y => y.DeparmentID).FirstOrDefault()).Sum(w => w.EmployeeSalary);
            return View();
        }
    }
}