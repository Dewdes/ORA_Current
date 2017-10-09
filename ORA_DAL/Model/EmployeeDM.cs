﻿using System;
using ORA.Models;
using ORA_Data.Model;

namespace ORA_DAL.Model
{
    public class EmployeeDM : AddressDM
    {
        public Int64 EmployeeId { get; set; }

        public string EmployeeNumber { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeMiddle { get; set; }

        public string EmployeeLastName { get; set; }

        public int Age { get; set; }

        public string BirthDate { get; set; }

        public Int64 AddressID { get; set; }

        public Int64 TimeID { get; set; }

        public Int64 WorkStatusID { get; set; }

        public AddressDM address { get; set; }

        public EmployeeTimeDM employeeTime { get; set; }

        public ClientsDM client { get; set; }

        public PositionsDM position { get; set; }

        public TeamsDM team { get; set; }

        public StatusDM workStatus { get; set; }
    }
}