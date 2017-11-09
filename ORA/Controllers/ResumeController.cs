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
            resume.Education = Mapper.Map<EducationVM>(ResumeDAL.GetEducationByResumeID(resume.ResumeID));
            resume.Skills = Mapper.Map<SkillsVM>(ResumeDAL.GetSkillsByResumeID(resume.ResumeID));
            resume.WorkHistory = Mapper.Map<WorkHistoryVM>(ResumeDAL.GetWorkHistoryByResumeID(resume.ResumeID));
            resume.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            return View(resume);
        }

        public ActionResult test()
        {
            return View();
        }

        public ActionResult ReadResumeEducationById(EducationVM education)
        {
            ResumeVM resume = new ResumeVM();
            EducationVM list = Mapper.Map<List<EducationVM>>(ResumeDAL.GetEducationByResumeID(resume.ResumeID));
            return View(list);
        }

        public ActionResult UpdateResumeEducation()
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            resume.Education = Mapper.Map<EducationVM>(ResumeDAL.GetEducationByResumeID(resume.ResumeID));
            return View(resume);
        }

        [HttpPost]
        public ActionResult UpdateResumeEducation(ResumeVM resume)
        {
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.UpdateEducation(Mapper.Map<EducationDM>(resume.Education), resume.ResumeID);
            return View();
        }

        public ActionResult CreateResumeEducation()
        {
            ResumeVM resume = new ResumeVM();
            return View(resume);
        }

        [HttpPost]
        public ActionResult CreateResumeEducation(ResumeVM resume)
        {
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.CreateEducation(Mapper.Map<EducationDM>(resume.Education), resume.ResumeID);
            return View();
        }
    }
}