using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reportsapi.Models
{
    public class Sale
    {
        public string id { get; set; }
        public string personId { get; set; }
        public string clientId { get; set; }
        public long inventoryId { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public decimal tax { get; set; }
        public int quantity { get; set; }
        public string created { get; set; }
        public string updated { get; set; }

    }
}