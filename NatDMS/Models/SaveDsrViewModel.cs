#nullable disable
using Natural.Core.Models;

namespace NatDMS.Models
{
    public class SaveDsrViewModel
    {
        public string Executive { get; set; }
        public string DistributorId { get; set; }
        public string RetailorId { get; set; }
        public string OrderBy { get; set; }
        public double TotalAmount { get; set; }
       // public string Dsr { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public List<ExecutiveModel> Executives { get; set; }
        public List<ProductModel> Products { get; set; }
        
    }
}
