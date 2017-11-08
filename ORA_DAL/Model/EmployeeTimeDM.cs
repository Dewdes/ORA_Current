namespace ORA_Data.Model
{
    public class EmployeeTimeDM
    {
        public long Time_ID { get; set; }

        public long Employee_ID { get; set; }

        public decimal Other_Total { get; set; }

        public decimal Other_Available { get; set; }

        public decimal Other_Used { get; set; }

        public decimal Payed_Total { get; set; }

        public decimal Payed_Available { get; set; }

        public decimal Payed_Used { get; set; }
    }
}
