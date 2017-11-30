using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class KPIController : Controller
    {
        // GET: KPI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateKPI()
        {
            KPIVM kpi = new KPIVM();
            kpi.EmployeeList = Mapper.Map<List<EmployeeVM>>(EmployeeDAL.ReadEmployees());
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());

            if ((string)Session["Role"] == "Director")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);

                return View(kpi);
            }
            else if ((string)Session["Role"] == "Manager")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 4);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);

                return View(kpi);
            }
            else if ((string)Session["Role"] == "Team Lead")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 3);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 4);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);

                return View(kpi);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "Default" });
            }
        }

        [HttpPost]
        public ActionResult CreateKPI(KPIVM kpi)
        {
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
            kpi.EmployeeList = Mapper.Map<List<EmployeeVM>>(EmployeeDAL.ReadEmployees());
            kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(kpi.EmployeeId));
            kpi.Employee.Assignment = Mapper.Map<AssignmentVM>(AssignmentDAL.ReadAssignmentByID(Convert.ToString(kpi.AssignmentId)));
            if ((string)Session["Role"] == "Director")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);

            }
            else if ((string)Session["Role"] == "Manager")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 4);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);

                
            }
            else if ((string)Session["Role"] == "Team Lead")
            {
                kpi.EmployeeList.RemoveAll(employee => employee.EmployeeId == (long)Session["ID"]);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 3);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 4);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 5);
                kpi.EmployeeList.RemoveAll(employee => employee.RoleId == 6);
            }

            if (ModelState.IsValid)
            {
                if (kpi.Start_Date < kpi.Employee.Assignment.StartDate || kpi.End_Date > kpi.Employee.Assignment.EndDate)
                {
                    ViewBag.message = string.Format("Invalid KPI Date. Please make sure Dates are in between assignment range for the employee.");
                    return View(kpi);
                }
                kpi.CreateDate = DateTime.Now;
                kpi.CreatedBy = Session["Email"].ToString();
                kpi.Modified = DateTime.Now;
                kpi.ModifiedBy = Session["Email"].ToString();
                KPI_DAL.CreateKPI(Mapper.Map<KPIDM>(kpi));
                return RedirectToAction("ReadKPIs", new { id = Session["ID"] });
            }
            else
            {
                if (kpi.Start_Date < kpi.Employee.Assignment.StartDate || kpi.End_Date > kpi.Employee.Assignment.EndDate)
                {
                    ViewBag.message = string.Format("Invalid KPI Date. Please make sure Dates are in between assigned range for the employee.");
                    return View(kpi);
                }
                return View(kpi);
            }
        }

        public ActionResult ReadKPIs(int id)
        {
            List<KPIVM> teamList = new List<KPIVM>();
            List<KPIVM> list = Mapper.Map<List<KPIVM>>(KPI_DAL.ReadKPIs());
            foreach (KPIVM item in list)
            {
                item.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(item.EmployeeId));
                item.Employee.Team = Mapper.Map<TeamsVM>(TeamsDAL.ReadTeamById(item.Employee.TeamId.ToString()));
            }
            if (Session["Role"].ToString() == "Team Lead")
            {
                EmployeeVM lead = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id));
                foreach (KPIVM assess in list)
                {
                    if (assess.AssignmentId == lead.AssignmentId && assess.Employee.EmployeeId != lead.EmployeeId)
                    {
                        teamList.Add(assess);
                    }
                }
                return View(teamList);
            }
            else if ((string)Session["Role"] == "Manager")
            {
                EmployeeVM manager = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id));
                foreach (KPIVM kpi in list)
                {
                    if (kpi.AssignmentId == manager.AssignmentId && kpi.Employee.EmployeeId != manager.EmployeeId)
                    {
                        teamList.Add(kpi);
                    }
                }
                return View(teamList);
            }
            else
            {
                return View(list);
            }
        }

        public ActionResult ReadMyKPIs(int id)
        {
            List<KPIVM> kpis = Mapper.Map<List<KPIVM>>(KPI_DAL.ReadMyKPIsById(id));
            foreach (KPIVM info in kpis)
            {
                info.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id));
            }
            return View(kpis);
        }

        public ActionResult ReadKPIByID(int id)
        {
            KPIVM kpi = Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(id));
            kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(kpi.EmployeeId));
            return View(kpi);
        }

        [HttpGet]
        public ActionResult UpdateKPI(int id)
        {
            if ((string)Session["Role"] == "Director" || (string)Session["Role"] == "Manager" || (string)Session["Role"] == "Team Lead")
            {
                KPIVM kpi = new KPIVM();
                kpi = Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(id));
                kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(kpi.EmployeeId));
                kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
                kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
                kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
                kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
                return View(kpi);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "Default" });
            }
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM kpi)
        {
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
            kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(kpi.EmployeeId));
            kpi.Employee.Assignment = Mapper.Map<AssignmentVM>(AssignmentDAL.ReadAssignmentByID(Convert.ToString(kpi.AssignmentId)));
            if (ModelState.IsValid)
            {
                if (kpi.Start_Date < kpi.Employee.Assignment.StartDate || kpi.End_Date > kpi.Employee.Assignment.EndDate)
                {
                    ViewBag.message = string.Format("Invalid KPI Date. Please make sure Dates are in between assignment range for the employee.");
                    return View(kpi);
                }
                kpi.Modified = DateTime.Now;
                kpi.ModifiedBy = Session["Email"].ToString();
                KPI_DAL.UpdateKPI(Mapper.Map<KPIDM>(kpi));
                return RedirectToAction("ReadKPIs", new { id = Session["ID"] });
            }
            else
            {
                if (kpi.Start_Date < kpi.Employee.Assignment.StartDate || kpi.End_Date > kpi.Employee.Assignment.EndDate)
                {
                    ViewBag.message = string.Format("Invalid KPI Date. Please make sure Dates are in between assignment range for the employee.");
                    return View(kpi);
                }
                return View(kpi);
            }
        }

        public ActionResult DeleteKPI(int id)
        {
            if ((string)Session["Role"] == "Manager" || (string)Session["Role"] == "Director" || (string)Session["Role"] == "Team Lead")
            {
                KPI_DAL.DeleteKPI(Mapper.Map<KPIDM>(KPI_DAL.ReadKPIById(id)));
                return RedirectToAction("ReadKPIs", "KPI", new { id = (long)Session["ID"] });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "Default" });
            }
        }

        //public ActionResult UpdateEmpListByDate(string startDate, string endDate)
        //{
        //    Convert.ToDateTime(startDate);
        //    Convert.ToDateTime(endDate);
        //    KPIVM kpi = new KPIVM();
        //    kpi.EmployeeList = Mapper.Map<List<EmployeeVM>>(EmployeeDAL.ReadEmployees());
        //    foreach(EmployeeVM employee in kpi.EmployeeList)
        //    {
        //        if(employee.Assignment.StartDate)
        //    }

        //    return View(kpi);

        //}
    }
}