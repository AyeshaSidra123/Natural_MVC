using Microsoft.AspNetCore.Mvc.Rendering;
using Natural.Core.Models;
using System.ComponentModel.DataAnnotations;


#nullable disable
namespace NatDMS.Models
{
    public class EDR_DisplayViewModel
    {
        [RegularExpression("[a-zA-Z]{1,40}", ErrorMessage = "must contain upto 40 alphabets only")]
        public string FirstName { get; set; }

        [RegularExpression("[a-zA-Z]{1,40}", ErrorMessage = "must contain upto 40 alphabets only")]
        public string LastName { get; set; }

        [RegularExpression("[a-zA-Z]{1,40}", ErrorMessage = "must contain upto 40 alphabets only")]
        public string FullName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<StateModel> StateList { get; set; }
        public List<ExecutiveModel> ExecutiveList { get; set; }
        public List<DistributorModel> DistributorList { get; set; }
        public List<RetailorModel> RetailorList { get; set; }
        public List<DsrModel> DsrList { get; set; }
        
      

    }
}
