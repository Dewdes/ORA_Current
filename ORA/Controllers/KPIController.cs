using AutoMapper;
using ORA.Mapping;
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
            kpi.EmployeeList = Mapper.Map<List<EmployeeVM>>(EmployeeMap.ReadEmployees());
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
            return View(kpi);
        }

        [HttpPost]
        public ActionResult CreateKPI(KPIVM kpi)
        {
            kpi.CreateDate = DateTime.Now;
            kpi.Modified = DateTime.Now;
            KPI_DAL.CreateKPI(Mapper.Map<KPIDM>(kpi));
            return RedirectToAction("AdminDashboard","Home");
        }

        public ActionResult ReadKPIs(int id)
        {
            List<KPIVM> teamList = new List<KPIVM>();
            List<KPIVM> list = Mapper.Map<List<KPIVM>>(KPI_DAL.ReadKPIs());
            foreach (KPIVM item in list)
            {
                item.Employee = EmployeeMap.GetEmployeeById(item.EmployeeId);
                item.Employee.Team = Mapper.Map<TeamsVM>(TeamsDAL.ReadTeamById(item.Employee.TeamId.ToString()));
            }
            if (Session["Role"].ToString() == "Team Lead")
            {
                EmployeeVM lead = Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(id));
                foreach (KPIVM assess in list)
                {
                    if (assess.Employee.TeamId == lead.TeamId && assess.Employee.EmployeeId != lead.EmployeeId)
                    {
                        teamList.Add(assess);
                    }
                }
                return View(teamList);
            }
            return View(list);
        }

        public ActionResult ReadMyKPIs(int id)
        {
            List<KPIVM> kpis = Mapper.Map<List<KPIVM>>(KPI_DAL.ReadMyKPIsById(id));
            foreach (KPIVM info in kpis)
            {
                info.Employee = Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(id));
            }
            return View(kpis);
        }

        public ActionResult ReadKPIByID(string id)
        {
            KPIVM kpi = Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(id));
            kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(kpi.EmployeeId));
            return View(kpi);
        }

        public ActionResult UpdateKPI(string id)
        {
            KPIVM kpi = new KPIVM();
            kpi = Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(id));
            kpi.Employee = Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(kpi.EmployeeId));
            kpi.Stories = Mapper.Map<List<StoryVM>>(StoryDAL.ReadStorys());
            kpi.Projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            kpi.Sprints = Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints());
            kpi.Assignments = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            return View(kpi);
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM kpi)
        {
            KPI_DAL.UpdateKPI(Mapper.Map<KPIDM>(kpi));
            return View(kpi);
        }

        public ActionResult DeleteKPI(string id)
        {
            KPIVM kpi = new KPIVM();
            kpi = Mapper.Map<KPIVM>(KPI_DAL.ReadKPIById(id));
            return View(kpi);
        }

        [HttpPost]
        public ActionResult DeleteKPI(KPIVM kpi)
        {
            KPI_DAL.DeleteKPI(Mapper.Map<KPIDM>(kpi));
            return View(kpi);
        }
    }
}