using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Batua.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int? Quantity { get; set; } = 0;
        public float? TotalAmount { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public virtual User UserID { get; set; }
    }
}