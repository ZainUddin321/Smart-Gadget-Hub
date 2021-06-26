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
            con.Open();
            string query = "select C_id,pname,ptype,price,payment_method,image,rating from Carts as c"
                           + " inner join Products as p on c.P_id = p.P_id"
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
    }
}