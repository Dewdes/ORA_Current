using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ORA.Models;
using ORA_Data.DAL;

namespace ORA.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult AverageAssessmentCharts(List<AssessmentVM> assessment)
        {
            return View();
        }

        public ActionResult TestKendo()
        {
           
            return View();
        }
    }
}