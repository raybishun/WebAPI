﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestModule1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}