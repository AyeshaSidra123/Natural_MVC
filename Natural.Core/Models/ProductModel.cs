using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Natural.Core.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Product1 { get; set; }
        public decimal? Price { get; set; }
        public string Quantity { get; set; }
        public int? Weight { get; set; }
        public string Amount { get; set; }
       
    }
}
