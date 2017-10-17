﻿using AutoMapper;
using ORA.Mapping;
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
            return View(EmployeeMap.ReadEmployees());
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

        #region ADMIN/MANAGER CREATE, READ, UPDATE, DELETE METHODS FOR SUPER USER

        public ActionResult EmployeeDetails(int id)
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(id)));
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
                EmployeeMap.CreateEmployee(employee);
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
            return View(Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(employeeId)));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM employee)
        {
            EmployeeMap.UpdateEmployee(employee);
            ModelState.Clear();
            return RedirectToAction("ViewEmployees");
        }

        /*TODO @Trevor Jones: Needs javascript functionality to reconfirm deletion of an employee. Deleting an employee shouldnt actually delete employ, but change work status
         *TODO:               and cascade delete everywhere else where that employee is being referenced. Keeping the employee in the system for records, but removing other info
         */

        [HttpGet]
        public ActionResult DeleteEmployee(int employeeId)
        {
            return View(Mapper.Map<EmployeeVM>(EmployeeMap.GetEmployeeById(employeeId)));
        }

        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeVM employee)
        {
            EmployeeMap.DeleteEmployee(employee);
            return RedirectToAction("ViewEmployees");
        }
        #endregion
    }
}