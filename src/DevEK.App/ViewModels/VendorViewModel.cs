using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace DevEK.App.ViewModels
{
    public class VendorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="The field {0} must be inform")]
        [StringLength(70, ErrorMessage="The field {0} must be between {2} and {1} caracters", MinimumLength =5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(14, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 11)]
        [DisplayName("Identifify ID")]
        public string IdentifiyDocument { get; set; }

        [DisplayName("Type of Vendor")]
        public int VendorType { get; set; }

        public AddressViewModel Address { get; set; }

        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
  
    }
}
