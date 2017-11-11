using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class StatusVM
    {
        public int StatusId { get; set; }

        [DisplayName("Employee Status")]
        public string EmployeeStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }

        [DisplayName("PayType")]
        public string PayType { get; set; }

        [DisplayName("Service Length")]
        public string ServiceLength { get; set; }

        [DisplayName("Employment Type")]
        public string EmploymentType { get; set; }

        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Termination Date")]
        public DateTime TerminationDate { get; set; }
    }
}