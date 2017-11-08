using System.Web.Mvc;
using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;

namespace ORA.Controllers
{
    public class ResumeController : Controller
    {
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
            if (ModelState.IsValid)
            {
                resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
                ResumeDAL.UpdateEducation(Mapper.Map<EducationDM>(resume.Education), resume.ResumeID);
                ResumeDAL.UpdateSkills(Mapper.Map<SkillsDM>(resume.Skills), resume.ResumeID);
                ResumeDAL.UpdateWorkHistory(Mapper.Map<WorkHistoryDM>(resume.WorkHistory), resume.ResumeID);
                return Redirect("ReadAccount");
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            EducationVM education = new EducationVM();
            return PartialView(education);
        }

        [HttpPost]
        public ActionResult AddEducation(EducationVM education)
        {
            if (ModelState.IsValid)
            {
                ResumeVM resume = new ResumeVM();
                resume.ResumeID = ResumeDAL.ReadResumeId((long) Session["ID"]);
                ResumeDAL.CreateEducation(Mapper.Map<EducationDM>(education), resume.ResumeID);
            }
            return Redirect("ReadAccount");
        }
    }
}