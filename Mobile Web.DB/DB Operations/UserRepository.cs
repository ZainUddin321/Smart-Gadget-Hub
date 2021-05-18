using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Web.Models;
namespace Mobile_Web.DB.DB_Operations
{
    public class UserRepository
    {
        public string createAccount(User_Model model)
        {
            using (var context = new Mobile_WebEntities())
            {
                User user = new User()
                {
                    username = model.username,
                    email = model.email,
                    country = model.country,
                    password = model.password
                };
                context.Users.Add(user);
                context.SaveChanges();


                return user.username;
            }
        }
        public bool loginAccount(User_Model model)
        {
            using(var context= new Mobile_WebEntities())
            {
                bool isValid = context.Users.Any(x => x.username == model.username && x.password == model.password);
                return isValid;
            };
        }

        public void insertData(string username,string pname, string type, int price, string method, string img)
        {
            using (var context = new Mobile_WebEntities())
            {
                Cart ct = new Cart()
                {
                    username = username,
                    product_name = pname,
                    product_type = type,
                    price = price,
                    payment_method = method,
                    image = img
                };
                context.Carts.Add(ct);
                context.SaveChanges();
            }
        }

        public bool deleteData(int id)
        {
            using(var context= new Mobile_WebEntities())
            {
                var data = context.Carts.FirstOrDefault(x => x.product_id == id);
                if(data!=null)
                {
                    context.Carts.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
