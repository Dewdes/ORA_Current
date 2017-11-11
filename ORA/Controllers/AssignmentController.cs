using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAssignment()
        {
            AssignmentVM assignment = new AssignmentVM();
            assignment.Clients = Mapper.Map<List<ClientsVM>>(ClientsDAL.ReadClients());
            assignment.Positions = Mapper.Map<List<PositionsVM>>(PositionsDAL.ReadPositions());
            return View(assignment);
        }

        [HttpPost]
        public ActionResult CreateAssignment(AssignmentVM assignment)
        {
            assignment.CreatedBy = Session["Email"].ToString();
            assignment.ModifiedBy = Session["Email"].ToString();
            assignment.Created = DateTime.Now;
            assignment.Modify = DateTime.Now;
            AssignmentDAL.CreateAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }

        public ActionResult ReadAssignments()
        {
            return View(Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments()));
        }

        public ActionResult ReadAssignmentByID(string id)
        {
            AssignmentVM assign = Mapper.Map<AssignmentVM>(AssignmentDAL.ReadAssignmentByID(id));
            return View(assign);
        }

        public ActionResult UpdateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAssignment(AssignmentVM assignment)
        {
            assignment.CreatedBy = Session["Email"].ToString();
            assignment.ModifiedBy = Session["Email"].ToString();
            assignment.Created = DateTime.Now;
            assignment.Modify = DateTime.Now;
            AssignmentDAL.UpdateAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }

        public ActionResult DeleteAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteAssignment(AssignmentVM assignment)
        {
            AssignmentDAL.DeleteAssignment(Mapper.Map<AssignmentDM>(assignment));
            return View();
        }
    }
}