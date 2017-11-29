using System;

namespace ORA_Data.Model
{
    public class KPIDM
    {
        public long KPIID { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal Points { get; set; }

        public int TCCreated { get; set; }

        public int TCExecuted { get; set; }

        public int TCFailed { get; set; }

        public int TCPassed { get; set; }

        public int TCBlocked { get; set; }

        public int DefectsFound { get; set; }

        public int DefectsFixed { get; set; }

        public int DefectsAccepted { get; set; }

        public int DefectsRejected { get; set; }

        public int DefectsDeferred { get; set; }

        public int CriticalDefects { get; set; }

        public decimal TestHrsPlanned { get; set; }

        public decimal TestHrsActual { get; set; }

        public int BugsFoundProduction { get; set; }

        public decimal TotalHrsFixingBugs { get; set; }

        public long Velocity { get; set; }

        public long Collaboration { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public long AssignmentId { get; set; }

        public long ProjectId { get; set; }

        public long SprintId { get; set; }

        public long StoryId { get; set; }

        public long EmployeeId { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }
        //new stuff
        public int RTCPassed { get; set; }

        public int RTCFailed { get; set; }

        public int RTCCreated { get; set; }

        public int RTCUpdated { get; set; }

        public int SprintTC_Passed { get; set; }

        public int SprintTC_Failed { get; set; }

        public int SprintTC_Created { get; set; }

        public int Defects_FoundInTesting { get; set; }

        public int Defects_FoundInProd { get; set; }

        public int Defects_RetestedFailed { get; set; }

        public int DefectsClosed { get; set; }

        public string TasksCompleted { get; set; }
        //ends new stuff
        public ProjectDM Project { get; set; }

        public StoryDM Story { get; set; }

        public SprintDM Sprint { get; set; }

        public EmployeeDM Employee { get; set; }
    }
}