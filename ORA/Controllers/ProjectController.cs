using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            ProjectVM proj = new ProjectVM();
            proj.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            return View(proj);
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectVM project)
        {
            project.CreatedBy = Session["Email"].ToString();
            project.ModifiedBy = Session["Email"].ToString();
            project.Created = DateTime.Now;
            project.Modified = DateTime.Now;
            ProjectDAL.CreateProject(Mapper.Map<ProjectDM>(project));
            return View();
        }

        public ActionResult ReadProjects()
        {
            List<ProjectVM> projects = Mapper.Map<List<ProjectVM>>(ProjectDAL.ReadProjects());
            return View(projects);
        }

        public ActionResult ReadProjectByID(ProjectDM project)
        {
            return View(Mapper.Map<ProjectVM>(ProjectDAL.ReadProjectById(project.ProjectId.ToString())));
        }

        public ActionResult UpdateProject()
        {
            ProjectVM proj = new ProjectVM();
            proj.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            return View(proj);
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectVM project)
        {
            project.ModifiedBy = Session["Email"].ToString();
            project.Modified = DateTime.Now;
            ProjectDAL.UpdateProject(Mapper.Map<ProjectDM>(project));
            return View();
        }

        public ActionResult DeleteProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProject(ProjectVM project)
        {
            ProjectDAL.DeleteProject(Mapper.Map<ProjectDM>(project));
            return View();
        }
    }
}