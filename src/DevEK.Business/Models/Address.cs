using System;
namespace DevEK.Business.Models
{
    public class Address : Entity
    {
        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } // EF Notation

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string PostCode { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Address()
        {
        }
    }
}
