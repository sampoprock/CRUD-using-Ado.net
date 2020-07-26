using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileReview.Models
{
    public class MobileModel
    {
        public int MobileID { get; set; }
        [DisplayName("Mobile Name")]
        [Required(ErrorMessage = "Product Name is required.")]
        public string MobileName { get; set; }
        [Required(ErrorMessage = "Mobile Price is required.")]
        [DisplayName("Price")]
        public decimal MobilePrice { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        [DisplayName("Brand")]
        public string MobileBrand { get; set; }
        [Required(ErrorMessage = "Rating is required.")]
        public decimal Rating { get; set; }
    }
}