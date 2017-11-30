using System;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class EducationVM
    {
        public int EducationID { get; set; }

        public string InsitutionName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM-yyyy}")]
        [Required(ErrorMessage = "This is required.")]
        public DateTime Attended_Start_Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM-yyyy}")]
        [Required(ErrorMessage = "This is required.")]
        public DateTime Attended_End_Date { get; set; }

        public string InstitutionLocation { get; set; }

        public string EducationEarned { get; set; }

        public string AreaOfStudy { get; set; }

        public int ResumeID { get; set; }
    }
}