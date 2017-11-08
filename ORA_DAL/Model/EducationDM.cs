using System;

namespace ORA_Data.Model
{
    public class EducationDM
    {
        public int EducationID { get; set; }

        public string InsitutionName { get; set; }

        public DateTime Attended_Start_Date { get; set; }

        public DateTime Attended_End_Date { get; set; }

        public string InstitutionLocation { get; set; }

        public string EducationEarned { get; set; }

        public string AreaOfStudy { get; set; }

        public int ResumeID { get; set; }
    }
}
