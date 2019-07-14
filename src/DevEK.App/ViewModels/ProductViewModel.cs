using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DevEK.App.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [DisplayName("Vendor")]
        public Guid VendorId { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(70, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(500, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Description { get; set; }

        [DisplayName("Upload Image")]
        public IFormFile ImageUpload { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        public decimal Value { get; set; }

        public DateTimeOffset Created { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        public VendorViewModel Vendor { get; set; }

        public IEnumerable<VendorViewModel> Vendors {get; set;}

    }
}
