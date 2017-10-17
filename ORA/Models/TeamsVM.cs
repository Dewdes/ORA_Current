﻿using System.Collections.Generic;
using System.ComponentModel;

namespace ORA.Models
{
    public class TeamsVM
    {
        public int TeamId { get; set; }

        [DisplayName("Team Name")]
        public string TeamName { get; set; }

        public int ClientId { get; set; }

        public List<ClientsVM> Clients { get; set; }
    }
}