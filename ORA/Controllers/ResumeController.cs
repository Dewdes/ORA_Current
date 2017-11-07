using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ORA.Mapping;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;

namespace ORA.Controllers
{
    public class ResumeController : Controller
    {
        public ActionResult ReadResumeById()
        {
            //Call each method and save it the the Resume Vm object, then place the resume Vm object inside of the View parameter
            //Allows us to view data from multiple modals in one view
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            resume.Education = Mapper.Map<EducationVM>(ResumeDAL.GetEducationByResumeID(resume.ResumeID));
            resume.Skills = Mapper.Map<SkillsVM>(ResumeDAL.GetSkillsByResumeID(resume.ResumeID));
            resume.WorkHistory = Mapper.Map<WorkHistoryVM>(ResumeDAL.GetWorkHistoryByResumeID(resume.ResumeID));
            resume.Employee =  Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById((long)Session["ID"]));
            return View(resume);
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(EducationDM _education)
        {
            return Redirect("ReadResumeById");
        }

        [HttpGet]
        public ActionResult UpdateResume()
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            resume.Education = Mapper.Map<EducationVM>(ResumeDAL.GetEducationByResumeID(resume.ResumeID));
            resume.Skills = Mapper.Map<SkillsVM>(ResumeDAL.GetSkillsByResumeID(resume.ResumeID));
            resume.WorkHistory = Mapper.Map<WorkHistoryVM>(ResumeDAL.GetWorkHistoryByResumeID(resume.ResumeID));
            return View(resume);
        }

        [HttpPost]
        public ActionResult UpdateResume(ResumeVM resume)
        {
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.UpdateEducation(Mapper.Map<EducationDM>(resume.Education), resume.ResumeID);
            ResumeDAL.UpdateSkills(Mapper.Map<SkillsDM>(resume.Skills), resume.ResumeID);
            ResumeDAL.UpdateWorkHistory(Mapper.Map<WorkHistoryDM>(resume.WorkHistory), resume.ResumeID);
            return Redirect("ReadAccount");
        }
    }
}