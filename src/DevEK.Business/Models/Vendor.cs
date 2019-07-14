using System;
using System.Collections.Generic;
using DevEK.Business.Models.Enums;

namespace DevEK.Business.Models
{
    public class Vendor : Entity
    {
        public string Name { get; set; }

        public string IdentifiyDocument { get; set; }

        public VendorType VendorType { get; set; }

        public Address Address { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public Vendor()
        {
        }

    }
}
