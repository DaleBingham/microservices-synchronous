using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reportsapi.Models
{
    public class Report
    {
        public Report() {
            // make it all new and addressable
            person = new Person();
            inventory = new Inventory();
            sale = new Sale();
            client = new Client();
        }

        // the Person API result
        public Person person { get; set; }
        /// the Inventory bought
        public Inventory inventory { get; set; }
        /// the Sale of the inventory to a person and client/company
        public Sale sale {get; set;}
        /// the client or company the person is buying this inventory item from
        public Client client {get; set;}
    }
}