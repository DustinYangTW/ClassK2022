using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View04Model.Models;
using View04Model.ViewModels;

namespace View04Model.Controllers
{
    public class HomeController : Controller
    {
        dbEmployeeEntities db = new dbEmployeeEntities()
;        // GET: Home
        public ActionResult Index(int depId = 1)
        {
            VMEmpoyee vmep = new VMEmpoyee()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(m => m.fDepId == depId).ToList()
            };

            //var employee = db.tEmployee.ToList();
            return View(vmep);
        }
    }
}