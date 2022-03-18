using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzzeria_Ver1._0.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int CustomerID { get; set; }
        public int OrderID { get; set; }

        public bool Is_delivered { get; set; }
    }
}