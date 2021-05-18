using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Web.Models
{
    public class Cart_Model
    {
        public int product_id { get; set; }
        public string username { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public int price { get; set; }
        public string payment_method { get; set; }
        public string image { get; set; }

        public virtual User_Model User { get; set; }
    }
}
