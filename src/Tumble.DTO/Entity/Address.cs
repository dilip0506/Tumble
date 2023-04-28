using System;
using System.Collections.Generic;
using System.Text;

namespace Tumble.DTO.Entity
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string StreetOptional { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
