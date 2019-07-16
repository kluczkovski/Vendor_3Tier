using System;
namespace DevEK.Business.Models
{
    public class Product : Entity
    {
        public Guid VendorId { get; set; }
        public Vendor Vendor { get; set; } // EF Notation


        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Value { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool IsActive { get; set; }

        public Product()
        {
            Created = DateTime.UtcNow;
        }
    }
}
