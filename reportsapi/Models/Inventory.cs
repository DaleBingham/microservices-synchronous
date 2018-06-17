using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reportsapi.Models
{
    public class Inventory
    {
        
        public string name { get; set; }
        
        public string description { get; set; }
        
        public decimal price { get; set; }
        
        public decimal saleprice { get; set; }
        
        public int quantity { get; set; }
        
        public int id { get; set; }
        
        /// placeholder for the manufacturer of this item
        public int company { get; set; }
    }
}