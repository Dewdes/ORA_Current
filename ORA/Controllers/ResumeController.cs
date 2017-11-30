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

        /// <summary>
        /// Reading employee information and getting the resume ID from the logged in employee
        /// </summary>
        /// <returns></returns>
        public ActionResult ReadResumeById()
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            resume.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            return View(resume);
        }

        /// <summary>
        /// This action is getting the resume ID, the getting all educations for the given resume
        /// </summary>
        /// <param name="educationList"></param>
        /// <returns></returns>
        public ActionResult ReadResumeEducationById(IEnumerable<EducationVM> educationList)
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long)Session["ID"]));
            educationList = Mapper.Map<List<EducationVM>>(ResumeDAL.GetListOfEducationsByResumeID(resume.ResumeID));
            return View(educationList);
        }

        /// <summary>
        /// This action is getting the resume ID, the getting all work history for the given resume
        /// </summary>
        /// <param name="workHistory"></param>
        /// <returns></returns>
        public ActionResult ReadresumeByWorkHistoryId(WorkHistoryVM workHistory)
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long) Session["ID"]));
            IEnumerable<WorkHistoryVM> list = Mapper.Map<List<WorkHistoryVM>>(ResumeDAL.GetListOfWorkHistoryByResumeID(resume.ResumeID));
            return View(list);
        }

        /// <summary>
        /// This action is reading getting the resume ID, the getting all skills that were added to the given resume
        /// </summary>
        /// <param name="skills"></param>
        /// <returns></returns>
        public ActionResult ReadResumeBySkillsId(SkillsVM skills)
        {
            ResumeVM resume = new ResumeVM();
            resume = Mapper.Map<ResumeVM>(ResumeDAL.GetResumeByID((long) Session["ID"]));
            IEnumerable<SkillsVM> skillList = Mapper.Map<List<SkillsVM>>(ResumeDAL.GetListOfSkillsByResumeID(resume.ResumeID));
            foreach (SkillsVM item in skillList)
            {
                item.SkillLibrary = Mapper.Map<SkillLibraryVM>(ResumeDAL.GetLibrarySkillsByID(item.SkillLibraryId));
            }
            return View(skillList);
        }

        /// <summary>
        /// Gets the Resume ID then gets the education information where it has the given resumeID
        /// </summary>
        /// <returns></returns>
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
            return RedirectToAction("ReadResumeById");
        }

        /// <summary>
        /// Creates a new education for the provided employee
        /// </summary>
        /// <returns></returns>
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
            ResumeDAL.CreateEducation(Mapper.Map<EducationDM>(education), resume.ResumeID);
            return RedirectToAction("ReadResumeById");
        }

        /// <summary>
        /// Creates a new work history for the provided employee
        /// </summary>
        /// <returns></returns>
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
            ResumeDAL.UpdateWorkHistory(Mapper.Map<WorkHistoryDM>(workHistory), resume.ResumeID);
            return View();
        }

        /// <summary>
        /// Updates the selected work history resume field
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateResumeWorkHistory()
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            WorkHistoryVM workHistory = Mapper.Map<WorkHistoryVM>(ResumeDAL.GetWorkHistoryByResumeID(resume.ResumeID));
            return View(workHistory);
        }

        [HttpPost]
        public ActionResult UpdateResumeWorkHistory(WorkHistoryVM workHistory)
        {
            ResumeVM resume = new ResumeVM();
            resume.ResumeID = ResumeDAL.ReadResumeId((long)Session["ID"]);
            ResumeDAL.UpdateWorkHistory(Mapper.Map<WorkHistoryDM>(workHistory), resume.ResumeID);
            return RedirectToAction("ReadResumeById");
        }
    }
}