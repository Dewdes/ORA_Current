using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Collections.Generic;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountCreation()
        {
            EmployeeVM employee = new EmployeeVM();
            employee.TeamList = Mapper.Map<List<TeamsVM>>(TeamsDAL.ReadTeams());
            employee.AssignmentList = Mapper.Map<List<AssignmentVM>>(AssignmentDAL.ReadAssignments());
            employee.RoleList = Mapper.Map<List<RolesVM>>(RolesDAL.ReadRoles());
            return View(employee);
        }

        [HttpPost]
        public ActionResult AccountCreation(EmployeeVM employee)
        {
            //LoginVM login = Mapper.Map<LoginVM>(LoginDAL.ReadLoginById(LoginDAL.ReadLoginByEmail(employee.Address.Email).ToString()));
            //if (login == null)
            //{
                EmployeeDAL.CreateEmployee(Mapper.Map<EmployeeDM>(employee));
                employee.EmployeeId = EmployeeDAL.ReadEmployeeId(employee.EmployeeNumber);
                employee.Login.Email = employee.Address.Email;
                employee.Login.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                employee.Login.Password = ORA_Data.Hash.GetHash(employee.Login.Password + employee.Login.Salt);
                LoginDAL.Register(Mapper.Map<LoginDM>(employee.Login), employee.EmployeeId);
                AddressDAL.CreateAddress(Mapper.Map<AddressDM>(employee.Address), employee.EmployeeId);
                Work_StatusDAL.CreateStatus(Mapper.Map<StatusDM>(employee.Status), employee.EmployeeId);
                //AccountDAL.CreateBio(Mapper.Map<AccountBioDM>(employee.Bio), employee.EmployeeId);
                TimeDAL.CreateEmptyTime(employee.EmployeeId);
                ResumeDAL.CreateResume(employee.EmployeeId);
                return RedirectToAction("AdminDashboard","Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("Email", "Email already exist");
            //    return View(employee);
            //}
        }

        public ActionResult CreateAccount()
        {
            return View();
        }


        public ActionResult ReadAccount()
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            employee.Address = Mapper.Map<AddressVM>(AddressDAL.ReadAddressByID(employee.EmployeeId.ToString()));
            employee.Bio = Mapper.Map<AccountBioVM>(AccountDAL.ReadBioById(employee.EmployeeId.ToString()));
            return View(employee);
        }

        [HttpPost]
        public ActionResult ReadAccount(EmployeeVM item)
        {
            EmployeeDAL.UpdateEmployee(Mapper.Map<EmployeeDM>(item));
            AddressDAL.UpdateAddress(Mapper.Map<AddressDM>(item.Address));
            AccountDAL.UpdateAboutMe(item.EmployeeId, item.Bio.AboutMe);
            return View(item);
        }

        public ActionResult UpdateAccount()
        {
            return View();
        }

        public ActionResult DeleteAccount()
        {
            return View();
        }
    }
}