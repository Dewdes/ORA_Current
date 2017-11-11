using System;

namespace ORA_Data.Model
{
    public class SprintDM
    {
        public long SprintId { get; set; }

        public string SprintNumber { get; set; }

        public string SprintName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }
        
        public long ClientId { get; set; }
    }
}