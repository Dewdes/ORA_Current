using System.ComponentModel;

namespace ORA.Models
{
    public class PositionsVM
    {
        public int PositionId { get; set; }

        [DisplayName("Position Name")]
        public string PositionName { get; set; }
    }
}