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
        public DateTime Start_Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime End_Date { get; set; }

        public int AssignmentId { get; set; }

        public AssignmentVM Assignment { get; set; }

        public List<AssignmentVM> Assignments { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeVM Employee { get; set; }

        [DisplayName("Employees")]
        public List<EmployeeVM> EmployeeList { get; set; }

        public int ProjectId { get; set; }

        public ProjectVM Project { get; set; }

        public List<ProjectVM> Projects { get; set; }

        public int SprintId { get; set; }

        public SprintVM Sprint { get; set; }

        public List<SprintVM> Sprints { get; set; }

        public int StoryId { get; set; }

        public StoryVM Story { get; set; }

        public List<StoryVM> Stories { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }
    }
}