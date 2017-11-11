using System.ComponentModel;

namespace ORA.Models
{
    public class EmployeeTimeVM
    {
        public int Time_ID { get; set; }

        public int Employee_ID { get; set; }

        [DisplayName("Other Time Total")]
        public decimal Other_Total { get; set; }

        [DisplayName("Other Time Available")]
        public decimal Other_Available { get; set; }

        [DisplayName("Other Time Used")]
        public decimal Other_Used { get; set; }

        [DisplayName("PTO Total")]
        public decimal Payed_Total { get; set; }

        [DisplayName("PTO Available")]
        public decimal Payed_Available { get; set; }

        [DisplayName("PTO Used")]
        public decimal Payed_Used { get; set; }
    }
}