using System.ComponentModel;

namespace ORA.Models
{
    public class ClientsVM
    {
        public int ClientId { get; set; }

        [DisplayName("Client Name")]
        public string ClientName { get; set; }

        [DisplayName("Client Abbreviation")]
        public string ClientAbbreviation { get; set; }
    }
}