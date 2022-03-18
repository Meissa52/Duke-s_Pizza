using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pizzzeria_Ver1._0.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is Required.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm-Password is Required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Should be Same!!")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fullname is Required.")]
        public string Fullname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is Required.")]
        public string Phone { get; set; }
    }
}