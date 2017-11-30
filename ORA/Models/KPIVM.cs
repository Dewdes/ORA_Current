using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class KPIVM
    {
        public int KPIID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Created Date")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Points")]
        public decimal Points { get; set; }

        [DisplayName("Created")]
        public int TCCreated { get; set; }

        [DisplayName("Executed")]
        public int TCExecuted { get; set; }

        [DisplayName("Failed")]
        public int TCFailed { get; set; }

        [DisplayName("Passed")]
        public int TCPassed { get; set; }

        [DisplayName("Blocked")]
        public int TCBlocked { get; set; }

        [DisplayName("Defects Found")]
        public int DefectsFound { get; set; }

        [DisplayName("Defects Fixed")]
        public int DefectsFixed { get; set; }

        [DisplayName("Defects Accepted")]
        public int DefectsAccepted { get; set; }

        [DisplayName("Defects Rejected")]
        public int DefectsRejected { get; set; }

        [DisplayName("Defects Deferred")]
        public int DefectsDeferred { get; set; }

        [DisplayName("Critical Defects")]
        public int CriticalDefects { get; set; }

        [DisplayName("Test Hours Planned")]
        public decimal TestHrsPlanned { get; set; }

        [DisplayName("Test Hours Actual")]
        public decimal TestHrsActual { get; set; }

        [DisplayName("Bugs Found Production")]
        public int BugsFoundProduction { get; set; }

        [DisplayName("Total Hours Fixing Bugs")]
        public decimal TotalHrsFixingBugs { get; set; }

        public long Velocity { get; set; }

        public long Collaboration { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        [Required(ErrorMessage ="This is a required field.")]
        public DateTime Start_Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        [Required(ErrorMessage = "This is a required field.")]
        public DateTime End_Date { get; set; }

        [DisplayName("Assignment")]
        [Required(ErrorMessage ="This is a required field.")]
        public int AssignmentId { get; set; }

        public AssignmentVM Assignment { get; set; }

        public List<AssignmentVM> Assignments { get; set; }

        [DisplayName("Employees")]
        [Required(ErrorMessage = "This is a required field.")]
        public int EmployeeId { get; set; }

        public EmployeeVM Employee { get; set; }

        [DisplayName("Employees")]
        public List<EmployeeVM> EmployeeList { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "This is a required field.")]
        public int ProjectId { get; set; }

        public ProjectVM Project { get; set; }

        public List<ProjectVM> Projects { get; set; }

        [DisplayName("Sprint")]
        [Required(ErrorMessage = "This is a required field.")]
        public int SprintId { get; set; }

        public SprintVM Sprint { get; set; }

        public List<SprintVM> Sprints { get; set; }

        [Required(ErrorMessage = "This is a required field.")]
        public int StoryId { get; set; }

        public StoryVM Story { get; set; }

        public List<StoryVM> Stories { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }
        //new stuff-----------------
        [DisplayName("Reg. Test Cases Passed")]
        public int RTCPassed { get; set; }

        [DisplayName("Reg. Test Cases Failed")]
        public int RTCFailed { get; set; }

        [DisplayName("Reg. Test Cases Created")]
        public int RTCCreated { get; set; }
        [DisplayName("Reg. Test Cases Updated")]
        public int RTCUpdated { get; set; }
        [DisplayName("Sprint Test Cases Passed")]
        public int SprintTC_Passed { get; set; }
        [DisplayName("Sprint Test Cases Failed")]
        public int SprintTC_Failed { get; set; }
        [DisplayName("Sprint Test Cases Created")]
        public int SprintTC_Created { get; set; }
        [DisplayName("Defects found in Testing")]
        public int Defects_FoundInTesting { get; set; }
        [DisplayName("Defects found in Production")]
        public int Defects_FoundInProd { get; set; }
        [DisplayName("Defects Retested & Failed")]
        public int Defects_RetestedFailed { get; set; }
        [DisplayName("Defects Closed")]
        public int DefectsClosed { get; set; }
        [DisplayName("Tasks Completed")]
        public string TasksCompleted { get; set; }
        //end of new stuff--------------
    }
}