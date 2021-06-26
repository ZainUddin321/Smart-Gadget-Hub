using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Mobile_Web.Models
{
    public class User_Model
    {
        public int U_id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string email { get; set; }
        public string country { get; set; }

    }
}
