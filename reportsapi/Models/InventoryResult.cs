using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reportsapi.Models
{
    /// This is the class that gets the Inventory information from the API
    /// we use the data piece of this
    public class InventoryResult
    {
        public InventoryResult() {
            data = new Inventory();
        }
        
        public string status { get; set; }
        public Inventory data { get; set; }
        public string message { get; set; }
    }
}