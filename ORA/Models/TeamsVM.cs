using System.Collections.Generic;
using System.ComponentModel;

namespace ORA.Models
{
    public class TeamsVM
    {
        public long TeamId { get; set; }

        [DisplayName("Team Name")]
        public string TeamName { get; set; }

        public long ClientId { get; set; }

        public List<ClientsVM> Clients { get; set; }
    }
}