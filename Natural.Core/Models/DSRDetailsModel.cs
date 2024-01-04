using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Natural.Core.Models
{
    public class DSRDetailsModel
    {
        public string Id { get; set; }
        public string Dsr { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}
