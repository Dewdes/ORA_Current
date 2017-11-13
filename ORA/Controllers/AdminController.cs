using System.Collections.Generic;
using System.Web.Mvc;
using ORA.Models;
using ORA_Data.DAL;
using AutoMapper;

namespace ORA.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult AverageAssessmentCharts(AssessmentVM assessment)
        {
            return View();
        }
    }
}