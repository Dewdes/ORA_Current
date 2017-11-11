using System;

namespace ORA_Data.Model
{
    public class AssignmentDM
    {
        public long AssignmentId { get; set; }

        public string AssignmentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long ClientId { get; set; }

        public long PositionId { get; set; }

        public DateTime Modify { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public AssessmentDM Assessment { get; set; }

        public PositionsDM Position { get; set; }

        public RolesDM Role { get; set; }

        public KPIDM KPI { get; set; }

        public ClientsDM Client { get; set; }
    }
}