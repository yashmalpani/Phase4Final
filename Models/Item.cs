using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4Final.Models
{
    public class Item
    {
        [Key]
        public int CartId { get; set; }
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
