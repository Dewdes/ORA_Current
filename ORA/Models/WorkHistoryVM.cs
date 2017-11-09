using System;

namespace ORA.Models
{
    public class WorkHistoryVM
    {
        public int WorkHistoryID { get; set; }

        public string OrganizationName { get; set; }

        public DateTime WorkPlaceStartDate { get; set; }

        public DateTime WorkPlaceEndDate { get; set; }

        public string JobDescription { get; set; }

        public string WorkPlaceLocation { get; set; }

        public int ResumeID { get; set; }
    }
}