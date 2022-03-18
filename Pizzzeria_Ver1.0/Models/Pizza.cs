using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pizzzeria_Ver1._0.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; }

        public int OrderID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You have to choose what size")]
        public string Size { get; set; }


        public bool Cheese { get; set; }
        public Boolean Blackolives { get; set; }
        public Boolean Bacon { get; set; }
        public Boolean Greenpeppers { get; set; }
        public Boolean Pinapple { get; set; }
        public Boolean Mushroom { get; set; }
        public Boolean Spinach { get; set; }
        public Boolean Onions { get; set; }
        public Boolean Shrimp { get; set; }
        public Boolean Sausages { get; set; }
        public Boolean Chicken { get; set; }

        public double Price { get; set; }
    }
}