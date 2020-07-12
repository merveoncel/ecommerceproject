using ecommerceproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ecommerceproject.Models
{
    public class Item
    {
        public Malzeme Malzeme { get; set; }

        public  Malzeme Title
        { get; set; }
         
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}