﻿using System.ComponentModel.DataAnnotations;

namespace RestModule1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required,StringLength(15)]
        public string Name { get; set; }
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }
    }
}