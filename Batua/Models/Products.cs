﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Batua.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public float GST { get; set; }
    }
}