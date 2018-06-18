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
            Data = new Inventory();
        }
        
        public string Status { get; set; }
        public Inventory Data { get; set; }
        public string Message { get; set; }
    }
}