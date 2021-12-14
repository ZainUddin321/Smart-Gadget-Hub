using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobile_Web.DB.DB_Operations;
using Mobile_Web.DB;
using Mobile_Web.Models;
using System.Data;
using System.Data.SqlClient;
namespace Mobile_Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        SqlConnection con = new SqlConnection(Connection.ConnectionString);
        UserRepository repo = null;
        public CartController()
        {
            repo = new UserRepository();
        }
        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.username = UserRepository.username;
            ViewBag.email = UserRepository.email;
            con.Open();
            string query = "select C_id,username,email,pname,ptype,price,payment_method,image,rating,Discount from Carts as c"
                           + " inner join Products as p on c.P_id = p.P_id"
                           + " inner join Users as u on c.U_id=u.U_id"
                           +" where c.U_id = '"+ UserRepository.userid + "'";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            data.Fill(dtable);
            /*var dbproduct = context.Carts
                .Select(x => new Cart_Model()
                {
                    product_id = x.product_id,
                    username = x.username,
                    product_name = x.product_name,
                    product_type = x.product_type,
                    price = x.price,
                    payment_method = x.payment_method,
                    image = x.image
                }).Where(x=>x.username==User.Identity.Name).ToList();*/
            return View(dtable);
        }
        public ActionResult getProduct(int pid)
        {
            con.Open();
            string query = "Select * from Carts where P_id='"+pid+"' and U_id='"+UserRepository.userid+"'" ;
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dtable = new DataTable();
            data.Fill(dtable);
            if (dtable.Rows.Count == 1)
            {
                TempData["DuplicateRecord"] = "This product is already in your cart.";
                return RedirectToAction("Accessories", "Home");
            }
            else
            {
                repo.insertData(pid);
            }
            /*using (var context = new Mobile_WebEntities())
            {
                bool isRecordAlreadyExists = context.Carts.Any(x => x.product_name == name && x.username==User.Identity.Name);
                if (isRecordAlreadyExists)
                {
                    TempData["DuplicateRecord"]= "This product is already in your cart.";
                    return RedirectToAction("Accessories", "Home");
                }
            };*/
            return RedirectToAction("Index");
        }
        public ActionResult deleteCart(int id)
        {
            repo.deleteData(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult addOrder(string username,string email,string phone,string address,string pinnumber)
        {
            con.Open();
            string query = "select P_id from Carts where U_id='"+ UserRepository.userid + "'";
            SqlDataAdapter data = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            int[] arr = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                arr[i] = Convert.ToInt32(dt.Rows[i]["P_id"]);
            }
            string query1 = "";
            for(int i=0;i<arr.Length; i++)
            {
                query1 = "insert into Orders values('"+ UserRepository.userid + "','" + arr[i] + "','" + address + "','" + phone + "','" + pinnumber + "')";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
            }
            string query3 = "delete from Carts where U_id='" + UserRepository.userid + "'";
            SqlCommand cmd1 = new SqlCommand(query3, con);
            cmd1.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }
    }
}