using AutoMapper;
using ORA.Models;
using ORA_Data.DAL;
using ORA_Data.Model;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: List of Employees 
        //Initial Page Load, checks Session Role, returns List of employees based on role and role parameters
        public ActionResult ViewEmployees(EmployeeVM employee)
        {
            //This view is not accessable to regular employees
            //if (!string.IsNullOrEmpty((string)Session["Roles"]))
            //{
            //    if (Session["Roles"].ToString().ToUpper().Trim().Contains("DIRECTOR") || Session["Roles"].ToString().ToUpper().Trim().Contains("ADMINISTRATOR"))
            //    {
            return View(EmployeeDAL.ReadEmployees());
            //    }

            //    /*Service managers will team Leads and employees for specific Client AND Location*/
            //    else if (Session["Roles"].ToString().ToUpper().Trim().Contains("SERVICEMANAGER"))
            //    {
            //        return View(/*Returns a List of employees*/);
            //    }
            //    //else if (Session["Roles"].ToString().ToUpper().Trim().Contains("SERVICEMANAGER"))
            //    //{
            //        //return View(/*Returns a List of employees*/);
            //    //}

            //    /*Team Leads can only see employees within Team AND Location */
            //    else
            //        return View(/*Returns a List of employees*/);
            //}
            ////Else returns to Login if session is null or empty
            //else
            //    return RedirectToAction("", "", new { area = "" });
        }

        #region ADMIN/MANAGER CREATE, READ, UPDATE, DELETE METHODS

        public ActionResult EmployeeDetails(int id)
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(id)));
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(EmployeeVM employee)
        {
            try
            {
                EmployeeDAL.CreateEmployee(Mapper.Map<EmployeeDM>(employee));
                return RedirectToAction("Register", "Login", new { area = "Default" });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SortEmployeeBy()
        {
            /*Gets selection from dynamically loaded drop down and can sort by
             *Employee WorkStatus, Location, Client, Team, Project, Position
             */
            return View(/*Returns view based on selection*/);
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int employeeId)
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(employeeId)));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM employee)
        {
            EmployeeDAL.UpdateEmployee(Mapper.Map<EmployeeDM>(employee));
            ModelState.Clear();
            return RedirectToAction("ViewEmployees");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int employeeId)
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeDAL.ReadEmployeeById(employeeId)));
        }

        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeVM employee)
        {
            EmployeeDAL.DeleteEmployee(Mapper.Map<EmployeeDM>(employee));
            return RedirectToAction("ViewEmployees");
        }

        public ActionResult DeleteEmployeeRecords(EmployeeVM employee)
        {
            AccountDAL.DeleteEmployeeRecords(employee.EmployeeId);
            return RedirectToAction("ViewEmployees");
        }
        #endregion
    }
}