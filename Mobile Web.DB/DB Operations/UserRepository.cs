using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Web.Models;
using System.Data;
using System.Data.SqlClient;
namespace Mobile_Web.DB.DB_Operations
{
    public class UserRepository
    {
        public static int userid=0;
        public static string username = "";
        public static string email = "";
        SqlConnection con = new SqlConnection(Connection.ConnectionString);
        public string createAccount(User_Model model)
        {
            con.Open();
            string query = "insert into Users(username,password,email,country) values('"+model.username+ "','" + model.password + "','" + model.email + "','" + model.country + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return model.username;
            /*using (var context = new Mobile_WebEntities())
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
            }*/
        }
        public bool loginAccount(User_Model model)
        {
            con.Open();
            string query = "Select * from Users where username='"+model.username+"' and password='"+model.password+"'";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            data.Fill(dtable);
            if (dtable.Rows.Count == 1)
            {
                userid = Convert.ToInt32(dtable.Rows[0]["U_id"]);
                username = dtable.Rows[0]["username"].ToString();
                email= dtable.Rows[0]["email"].ToString();
                return true;
            }
            else
            {
                return false;
            }
            /*using (var context= new Mobile_WebEntities())
            {
                bool isValid = context.Users.Any(x => x.username == model.username && x.password == model.password);
                return isValid;
            };*/
        }
        public void insertData(int pid)
        {
            if (userid != 0)
            {
                con.Open();
                string query = "insert into Carts(U_id,P_id) values('" + userid + "','" + pid + "')";
                SqlDataAdapter dt = new SqlDataAdapter(query, con);
                dt.SelectCommand.ExecuteNonQuery();
                con.Close();
            }
        }
        public bool deleteData(int id)
        {
            try
            {
                con.Open();
                string query = "delete from Carts where C_id = '" + id + "'";
                SqlCommand data = new SqlCommand(query, con);
                data.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            /*using(var context= new Mobile_WebEntities())
            {
                var data = context.Carts.FirstOrDefault(x => x.product_id == id);
                if(data!=null)
                {
                    context.Carts.Remove(data);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }*/
        }
    }
}
