using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: Assessment
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Sort(string Sorting_Order, List<AssessmentVM> assessments)
        {
            List<AssessmentVM> SortedList = new List<AssessmentVM>();
            switch (Sorting_Order)
            {
                case ("name"):
                    {
                        SortedList = assessments.OrderBy(o => o.Employee.EmployeeFirstName).ToList();
                        return View(SortedList);
                    }
                case ("team"):
                    {
                        SortedList = assessments.OrderBy(o => o.Employee.Team.TeamName).ToList();
                        return View(SortedList);
                    }
                //case ("date"):
                //    {
                //        SortedList = assessments.OrderBy(o => o.Employee.Assignment.StartDate).ToList();
                //        return View(SortedList);
                //    }
            }
            return View(assessments);
        }

        public ActionResult SortByDateRange(DateTime start, DateTime end, List<AssessmentVM> assessments)
        {
            List<AssessmentVM> list = new List<AssessmentVM>();
            foreach(AssessmentVM assess in assessments)
            {
                if(start >= assess.Created && end <= assess.Created)
                {
                    list.Add(assess);
                }
            }
            return View(list);
        }

        public ActionResult CreateAssessment()
        {
            AssessmentVM assessment = new AssessmentVM();
            assessment.DateCreatedFor = DateTime.Now.Date;
            assessment.EmployeeList = Mapper.Map<List<EmployeeVM>>(EmployeeDAL.ReadEmployees());
            assessment.Descriptions = Mapper.Map<List<DescriptionVM>>(AssessmentDAL.ReadAssessDescriptions());
            return View(assessment);
        }

        [HttpPost]
        public ActionResult CreateAssessment(AssessmentVM assessment)
        {
            assessment.CreatedBy = Session["Email"].ToString();
            assessment.ModifiedBy = Session["Email"].ToString();
            assessment.Created = DateTime.Now;
            assessment.Modified = DateTime.Now;
            AssessmentDAL.CreateAssessment(Mapper.Map<AssessmentDM>(assessment));
            return RedirectToAction("ReadAssessments",new { id = Session["ID"] });
        }

        public ActionResult ReadAssessments(int id)
        {
            List<AssessmentVM> teamList = new List<AssessmentVM>();
            List<AssessmentVM> list = Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadAssessments());
            foreach (AssessmentVM item in list)
            {
                item.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(item.EmployeeID));
                item.Employee.Team = Mapper.Map<TeamsVM>(TeamsDAL.ReadTeamById(item.Employee.TeamId.ToString()));
            }
            if(Session["Role"].ToString() == "Team Lead")
            {
                EmployeeVM lead = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id));
                foreach(AssessmentVM assess in list)
                {
                    if(assess.Employee.TeamId == lead.TeamId && assess.Employee.EmployeeId != lead.EmployeeId)
                    {
                        teamList.Add(assess);
                    }
                }
                return View(teamList);
            }
            return View(list);
        }

        public ActionResult ReadAssessmentByID(string id)
        {
            AssessmentVM assess = Mapper.Map<AssessmentVM>(AssessmentDAL.ReadAssessmentByID(id));
            assess.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(assess.EmployeeID));
            return View(assess);
        }

        public ActionResult ReadMyAssessments(int id)
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id));
            List<AssessmentVM> list = Mapper.Map<List<AssessmentVM>>(AssessmentDAL.ReadMyAssessmentsByID(id));
            foreach (AssessmentVM item in list)
            {
                item.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(item.EmployeeID));
                item.Employee.Team = Mapper.Map<TeamsVM>(TeamsDAL.ReadTeamById(item.Employee.TeamId.ToString()));
            }
            return View(list);
        }

        public ActionResult UpdateAssessment(string id)
        {
            return View(Mapper.Map<AssessmentVM>(AssessmentDAL.ReadAssessmentByID(id)));
        }

        [HttpPost]
        public ActionResult UpdateAssessment(AssessmentVM assessment)
        {
            assessment.ModifiedBy = Session["Email"].ToString();
            assessment.Modified = DateTime.Now;
            AssessmentDAL.UpdateAssessment(Mapper.Map<AssessmentDM>(assessment));
            return View(assessment);
        }

        public ActionResult DeleteAssessment(string id)
        {
            AssessmentVM assessment = Mapper.Map<AssessmentVM>(AssessmentDAL.ReadAssessmentByID(id));
            return View(assessment);
        }

        [HttpPost]
        public ActionResult DeleteAssessment(AssessmentVM assessment)
        {
            AssessmentDAL.DeleteAssessment(Mapper.Map<AssessmentDM>(assessment));
            return View(assessment);
        }
    }
}