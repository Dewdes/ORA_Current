using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            assessment = Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadAssessments());
            return View(assessment);
        }

        public ActionResult TestView(List<AssessmentVM> assessmentList)
        {
            assessmentList = Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadAssessments());
            AssessmentVM assessment = new AssessmentVM();
            List<AssessmentVM.DataPoint> dataPoints = new List<AssessmentVM.DataPoint>();
            //List<AssessmentVM.DataPoint> dataPoints = new List<AssessmentVM.DataPoint>{
            //    new AssessmentVM.DataPoint(10, 22),
            //    new AssessmentVM.DataPoint(20, 36),
            //    new AssessmentVM.DataPoint(30, 42),
            //    new AssessmentVM.DataPoint(40, 51),
            //    new AssessmentVM.DataPoint(50, 46),
            //};

            assessment.MeanList = AssessmentFunctions.CalculateMeanForAllAssessments(Mapper.Map<List<AssessmentBM>>(assessmentList));
            int i = 1;
            foreach (double item in assessment.MeanList)
            {
                //for (int i = 0; i < 5; i++)
                //{
                dataPoints.Add(new AssessmentVM.DataPoint(i, item));
                    //{
                    //    new AssessmentVM.DataPoint(i, item)
                    //};
                i++;
                //}
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

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
                if (item.DateCreatedFor >= fromDateFilter && item.DateCreatedFor <= toDateFilter)
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