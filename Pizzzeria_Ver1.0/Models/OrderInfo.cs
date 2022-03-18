using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pizzzeria_Ver1._0.Models
{
    public class OrderInfo
    {
        public int OrderID { get; set; }

        public string OrderMethod { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to fill out Street Address.")]
        public string Street { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to fill out City.")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to select State.")]
        public string State { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to fill out Zip code.")]
        public Nullable<int> Zip { get; set; }

    }
}