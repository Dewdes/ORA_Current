﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
﻿using System;

namespace ORA.Models
{
    public class AddressVM
    {
        public Int64 Address_ID { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Zip Code")]
        [DataType(DataType.PostalCode)]
        public int Zip_Code { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Int64 Employee_ID { get; set; }
    }
}
