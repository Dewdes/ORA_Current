using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Logic;
using ORA_Logic.Models;

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

        [HttpPost]
        public ActionResult FilterChartByDate(string fromDate, string toDate)
        {
            DateTime fromDateFilter = Convert.ToDateTime(fromDate);
            DateTime toDateFilter = Convert.ToDateTime(toDate);

            List<AssessmentVM> assessmentList = Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadAssessments());
            List<AssessmentVM> filteredList = new List<AssessmentVM>();
            foreach (AssessmentVM item in assessmentList)
            {
                if(item.DateCreatedFor >= fromDateFilter && item.DateCreatedFor <= toDateFilter)
                {
                    filteredList.Add(item);
                }
            }
        
            AssessmentFunctions.CalculateMeanForAllAssessments(Mapper.Map<List<AssessmentVM>, List<AssessmentBM>>(filteredList));
            AssessmentFunctions.CalculateStdDeviationForAllAssessments(Mapper.Map<List<AssessmentVM>, List<AssessmentBM>>(filteredList));
            return RedirectToAction("AverageAssessmentCharts", new { assessment = filteredList });
        }
    }
}