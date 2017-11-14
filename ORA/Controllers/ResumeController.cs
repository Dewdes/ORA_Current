using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;

namespace ORA.Controllers
{
    public class ResumeController : Controller
    {
        public ActionResult ReadMyResume()
        {
            return View();
        }

        public ActionResult ReadResumeById()
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            resume.Skills = Mapper.Map<SkillsVM>(ResumeDAL.GetSkillsByResumeID(resume.ResumeID));
            resume.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            return View(resume);
        }

        public ActionResult ReadResumeEducationById(EducationVM education)
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            IEnumerable<EducationVM> list = Mapper.Map<List<EducationVM>>(ResumeDAL.GetListOfEducationsByResumeID(resume.ResumeID));
            return View(list);
        }

        public ActionResult ReadresumeByWorkHistoryId(WorkHistoryVM workHistory)
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long) Session["ID"]));
            IEnumerable<WorkHistoryVM> list = Mapper.Map<List<WorkHistoryVM>>(ResumeDAL.GetListOfWorkHistoryByResumeID(resume.ResumeID));
            return View(list);
        }

        public ActionResult UpdateResumeEducation()
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            EducationVM education = Mapper.Map<EducationVM>(ResumeDAL.GetEducationsByResumeID(resume.ResumeID));
            return View(education);
        }

        [HttpPost]
        public ActionResult UpdateResumeEducation(EducationVM education)
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.UpdateEducation(Mapper.Map<EducationDM>(education), resume.ResumeID);
            return View(education);
        }

        public ActionResult CreateResumeEducation()
        {
            EducationVM education = new EducationVM();
            return View(education);
        }

        [HttpPost]
        public ActionResult CreateResumeEducation(EducationVM education)
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.CreateEducation(Mapper.Map<EducationDM>(resume.Education), resume.ResumeID);
            return View();
        }

        public ActionResult CreateResumeWorkHistory()
        {
            WorkHistoryVM workHistory = new WorkHistoryVM();
            return View(workHistory);
        }

        [HttpPost]
        public ActionResult CreateResumeWorkHistory(WorkHistoryVM workHistory)
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long) Session["ID"]);
            ResumeDAL.CreateWorkHistory(Mapper.Map<WorkHistoryDM>(resume.WorkHistory), resume.ResumeID);
            return View();
        }
    }
}