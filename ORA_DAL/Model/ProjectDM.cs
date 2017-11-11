using System;

namespace ORA_Data.Model
{
    public class ProjectDM
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public long ClientId { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}