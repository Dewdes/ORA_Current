using System;
using ORA.Models;
using System.Web.Mvc;
using ORA_Data.DAL;
using AutoMapper;
using ORA_Data.Model;
using System.Configuration;
using System.Collections.Generic;
using System.Web.Security;

namespace ORA.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(LoginVM info)
        {

            try
            {
                if (info.Password != info.ConfirmPassword) return View();
                info.Salt = Convert.ToBase64String(Salt.GenerateSalt());
                info.Password = ORA_Data.Hash.GetHash(info.Password + info.Salt);
                //LoginDAL.Register(Mapper.Map<LoginDM>(info));
                info.Password = "";
                return ConfigurationManager.AppSettings["RegisterToLogin"].ToLower() == "true"
                    ? RedirectToAction("Login", "Login", info) : RedirectToAction("Index", "Home", new { area = "Default" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if ((bool)Session["LoggedIn"])
            {
                if ((string)Session["Role"] == "ADMIN" || ((string)Session["Role"] == "DIRECTOR"))
                {
                    return RedirectToAction("AdminDashboard", "Admin", new { area = "Default" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Default" });
                }
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginVM info)
        {
            try
            {
                if (info.Email != null && LoginDAL.Login(Mapper.Map<LoginDM>(info)))
                {
                    Session["LoggedIn"] = true;
                    info.EmployeeId = LoginDAL.ReadLoginByEmail(info.Email);
                    info.Employee = Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(info.EmployeeId));
                    info.Role = Mapper.Map<RolesVM>(RolesDAL.ReadRoleByID(info.Employee.RoleId));
                    Session["Role"] = info.Role.RoleName;
                    Session["ID"] = info.EmployeeId;
                    Session["TeamId"] = info.Employee.TeamId;
                    Session["Email"] = info.Email;
                    Session["Name"] = info.Employee.EmployeeName;
                    FormsAuthentication.RedirectFromLoginPage(info.Role.RoleName, true);
                    FormsAuthentication.SetAuthCookie(info.Email, false);
                    if ((bool)Session["LoggedIn"])
                    {
                        if (Session["Role"].ToString().ToUpper().Contains("ADMIN") || Session["Role"].ToString().ToUpper().Contains("DIRECTOR"))
                        {
                            return RedirectToAction("AdminDashboard", "Admin", new { area = "Default" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Default" });
                        }
                    }
                }
                else
                {
                    List<LoginVM> list = Mapper.Map<List<LoginVM>>(LoginDAL.ViewLogins());
                    List<string> emails = new List<string>();
                    List<string> passwords = new List<string>();
                    List<string> salts = new List<string>();
                    foreach (LoginVM login in list)
                    {
                        emails.Add(login.Email);
                        passwords.Add(login.Password);
                        salts.Add(login.Salt);
                    }
                    if (!emails.Contains(info.Email))
                    {
                        ModelState.AddModelError("Email", "Incorrect Email or Password");
                    }
                    for (int i = 0; i <= (passwords.Count - 1); i++)
                    {
                        if (!passwords.Contains(ORA_Data.Hash.GetHash(info.Password + salts[i])))
                        {
                            ModelState.AddModelError("Password", "Incorrect Email or Password");
                        }

                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult LogOut()
        {
            Session["LoggedIn"] = false;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login", new { area = "Default" });
        }

        public ActionResult ReadLogins()
        {
            return View(Mapper.Map<List<LoginVM>>(LoginDAL.ViewLogins()));
        }

        public ActionResult ReadLoginByID(LoginDM login)
        {
            return View(Mapper.Map<LoginVM>(LoginDAL.ReadLoginById(login.LoginId.ToString())));
        }

        public ActionResult UpdateLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateLogin(LoginVM login)
        {
            LoginDAL.UpdateLogin(Mapper.Map<LoginDM>(login));
            return View();
        }

        public ActionResult DeleteLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteLogin(LoginVM login)
        {
            LoginDAL.DeleteLogin(Mapper.Map<LoginDM>(login));
            return View();
        }

    }
}