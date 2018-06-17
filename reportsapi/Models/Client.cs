using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace reportsapi.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Created { get; set; }
    }
}