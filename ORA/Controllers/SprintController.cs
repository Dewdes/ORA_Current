using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class SprintController : Controller
    {
        // GET: Sprint
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSprint(SprintVM sprint)
        {
            //sprint.CreatedBy = Session["Email"].ToString();
            //sprint.ModifiedBy = Session["Email"].ToString();
            sprint.Created = DateTime.Now;
            sprint.Modified = DateTime.Now;
            SprintDAL.CreateSprint(Mapper.Map<SprintDM>(sprint));
            return View();
        }

        public ActionResult ReadSprints()
        {
            return View(Mapper.Map<List<SprintVM>>(SprintDAL.ReadSprints()));
        }

        public ActionResult ReadSprintByID(SprintDM sprint)
        {
            return View(Mapper.Map<SprintVM>(SprintDAL.ReadSprintById(sprint.SprintId.ToString())));
        }

        public ActionResult UpdateSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSprint(SprintVM sprint)
        {
            sprint.Modified = DateTime.Now;
            SprintDAL.UpdateSprint(Mapper.Map<SprintDM>(sprint));
            return View();
        }

        public ActionResult DeleteSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSprint(SprintVM sprint)
        {
            SprintDAL.DeleteSprint(Mapper.Map<SprintDM>(sprint));
            return View();
        }
    }
}