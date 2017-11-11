using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(RolesVM role)
        {
            RolesDAL.CreateRole(Mapper.Map<RolesDM>(role));
            return View();
        }
        
        public ActionResult ReadRoles()
        {
            return View(Mapper.Map<List<RolesVM>>(RolesDAL.ReadRoles()));
        }

        public ActionResult ReadRoleByID(RolesDM role)
        {
            return View(Mapper.Map<RolesVM>(RolesDAL.ReadRoleByID(role.RoleId)));
        }

        public ActionResult UpdateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateRole(RolesVM role)
        {
            RolesDAL.UpdateRole(Mapper.Map<RolesDM>(role));
            return View();
        }

        public ActionResult DeleteRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteRole(RolesVM role)
        {
            RolesDAL.DeleteRole(Mapper.Map<RolesDM>(role));
            return View();
        }
    }
}