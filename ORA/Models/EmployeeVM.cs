using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class EmployeeVM 
    {
        public long EmployeeId { get; set; }

        [DisplayName("Employee Number")]
        public string EmployeeNumber { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("First Name")]
        public string EmployeeFirstName { get; set; }

        [DisplayName("Middle Name")]
        public string EmployeeMiddle { get; set; }

        [DisplayName("Last Name")]
        public string EmployeeLastName { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        //Objects of other models

        public long AddressId { get; set; }

        public AddressVM Address { get; set; }

        public List<AddressVM> AddressList { get; set; }

        public long TimeId { get; set; }

        public EmployeeTimeVM EmployeeTime { get; set; }

        public List<EmployeeTimeVM> EmployeeTimeList { get; set; }

        public long ClientId { get; set; }

        public ClientsVM Client { get; set; }

        public List<ClientsVM> ClientList { get; set; }

        public long PositionId { get; set; }

        public PositionsVM Position { get; set; }

        public List<PositionsVM> PositionList { get; set; }

        public long TeamId { get; set; }

        public TeamsVM Team { get; set; }

        public List<TeamsVM> TeamList { get; set; }

        public long StatusId { get; set; }

        public StatusVM Status { get; set; }

        public List<StatusVM> StatusList { get; set; }

        public long AssignmentId { get; set; }

        public AssignmentVM Assignment { get; set; }

        public List<AssignmentVM> AssignmentList { get; set; }

        public long RoleId { get; set; }

        public RolesVM Role { get; set; }

        public List<RolesVM> RoleList { get; set; }

        public long LoginId { get; set; }

        public LoginVM Login { get; set; }

        public ResumeVM Resume { get; set; }

        public EducationVM Education { get; set; }

        public SkillsVM Skills { get; set; }

        public WorkHistoryVM WorkHistory { get; set; }

        public long BioId { get; set; }

        public AccountBioVM Bio { get; set; }
    }
}