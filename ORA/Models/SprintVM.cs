using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class SprintVM
    {
        public long SprintId { get; set; }

        [DisplayName("Sprint Number")]
        public string SprintNumber { get; set; }

        [DisplayName("Sprint Name")]
        public string SprintName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public long ClientId { get; set; }
    }
}