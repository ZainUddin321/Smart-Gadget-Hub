using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Mobile_Web.Models
{
    public class Product_Model
    {
        public int P_id { get; set; }
        [DisplayName("Product Name")]
        public string pname { get; set; }
        [DisplayName("Product Type")]
        public string ptype { get; set; }
        [DisplayName("Price")]
        public Nullable<int> price { get; set; }
        [DisplayName("Payment Method")]
        public string payment_method { get; set; }
        public string image { get; set; }
        [DisplayName("Rating")]
        public Nullable<decimal> rating { get; set; }
        public string Chipset { get; set; }
        public string Size { get; set;}
        public string Memory { get; set; }
        public string MainCamera { get; set; }
        public string FrontCamera { get; set; }
        public string Battery { get; set; }
        public string OS { get; set; }
        public string Weight { get; set; }
    }
}
