using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Batua.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Title { get; set; }
        
        public virtual ICollection<Products> Products { get; set; }
    }
}