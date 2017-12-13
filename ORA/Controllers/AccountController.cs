using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Collections.Generic;
using System.Web;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Account Creation is for the Director role or administrator role to create a new account for a employee
        /// </summary>
        /// <returns></returns>
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
            //AccountDAL.CreateBio(employee.EmployeeId);
            return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ModelState.AddModelError("Email", "Email already exist");
            //    return View(employee);
            //}
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

        public ActionResult UploadProfileImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadProfileImage(AccountBioVM account)
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            if (account.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(account.File.ContentType == "image/jpeg" || account.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }

            byte[] data = new byte[account.File.ContentLength];
            account.File.InputStream.Read(data, 0, account.File.ContentLength);
            account.ProfileImage = data;
            AccountDAL.UpdateProfileImg(Mapper.Map<AccountBioDM>(account), employee.EmployeeId);
            return RedirectToAction("ReadAccount");
        }

        public ActionResult UploadBannerImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadBannerImage(AccountBioVM account)
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            if (account.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(account.File.ContentType == "image/jpeg" || account.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }

            byte[] data = new byte[account.File.ContentLength];
            account.File.InputStream.Read(data, 0, account.File.ContentLength);
            account.BannerBackgroundImg = data;
            AccountDAL.UpdateBackground(Mapper.Map<AccountBioDM>(account), employee.EmployeeId);
            return RedirectToAction("ReadAccount");
        }

        public ActionResult EditLayout()
        {
            AccountBioVM account = new AccountBioVM();
            account.ColorOptions = new List<string>(); account.ImageOptions = new List<string>();
            account.ColorOptions.Add("red"); account.ColorOptions.Add("azure"); account.ColorOptions.Add("purple");
            account.ColorOptions.Add("green"); account.ColorOptions.Add("orange"); account.ColorOptions.Add("blue");
            account.ImageOptions.Add("/Content/assets/img/sidebar-1.jpg"); account.ImageOptions.Add("/Content/assets/img/sidebar-2.jpg");
            account.ImageOptions.Add("/Content/assets/img/sidebar-3.jpg"); account.ImageOptions.Add("/Content/assets/img/sidebar-4.jpg");
            account.ImageOptions.Add("/Content/assets/img/sidebar-5.jpg");
            return View(account);
        }

        [HttpPost]
        public ActionResult EditLayout(AccountBioVM account)
        {
            EmployeeVM employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById((long)Session["ID"]));
            AccountDAL.UpdateSideMenu(Mapper.Map<AccountBioDM>(account), employee.EmployeeId);

            return RedirectToAction("ReadAccount");
        }
    }
}