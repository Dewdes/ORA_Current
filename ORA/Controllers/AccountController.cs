using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Web;
using ORA.Mapping;

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
            LoginVM login = Mapper.Map<LoginVM>(LoginDAL.ReadLoginById(LoginDAL.ReadLoginByEmail(employee.Address.Email).ToString()));
            if (login == null)
            {
                EmployeeMap.CreateEmployee(employee);
                employee.EmployeeId = EmployeeMap.GetEmployeeId(employee.EmployeeNumber);
                employee.Login.Email = employee.Address.Email;
                employee.Login.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                employee.Login.Password = ORA_Data.Hash.GetHash(employee.Login.Password + employee.Login.Salt);
                LoginDAL.Register(Mapper.Map<LoginDM>(employee.Login), employee.EmployeeId);
                AddressDAL.CreateAddress(Mapper.Map<AddressDM>(employee.Address), employee.EmployeeId);
                Work_StatusDAL.CreateStatus(Mapper.Map<StatusDM>(employee.Status), employee.EmployeeId);
                TimeDAL.CreateEmptyTime(employee.EmployeeId);
                ResumeDAL.CreateResume(employee.EmployeeId);
                return Redirect("AdminDashboard");
            }
            else
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View(employee);
            }
        }

        public ActionResult CreateAccount()
        {
            return View();
        }


        public ActionResult ReadAccount()
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById((long)Session["ID"]));
            employee.Address = Mapper.Map<AddressVM>(AddressDAL.ReadAddressByID(employee.EmployeeId.ToString()));
            return View(employee);
        }

        [HttpPost]
        public ActionResult ReadAccount(EmployeeVM item)
        {
            EmployeeMap.UpdateEmployee(item);
            AddressDAL.UpdateAddress(Mapper.Map<AddressDM>(item.Address));
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

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("ReadAccount", "Account");
        }
    }
}