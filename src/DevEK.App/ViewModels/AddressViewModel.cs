using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DevEK.App.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(70, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Street { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Number { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Complement { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(8, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 8)]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 5)]
        public string Region { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} must be inform")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} caracters", MinimumLength = 2)]
        public string State { get; set; }

        [HiddenInput]
        public Guid VendorId { get; set; }

        public AddressViewModel()
        {
        }
    }
}
