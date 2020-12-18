using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChartDemo.Models
{
    public class SaleOrder
    {
        [Key]
        public int Sale_id { get; set; }
        public int Zone { get; set; }
        public int Sale_Amount { get; set; }
    }
}
