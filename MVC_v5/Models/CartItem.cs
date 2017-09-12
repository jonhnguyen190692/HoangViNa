using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace MVC_v5.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}