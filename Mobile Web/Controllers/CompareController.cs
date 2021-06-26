using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobile_Web.DB;
using Mobile_Web.Models;
using System.Data;
using System.Data.SqlClient;
namespace Mobile_Web.Controllers
{
    public class CompareController : Controller
    {
        SqlConnection con = new SqlConnection(Connection.ConnectionString);
        // GET: Compare
        public ActionResult Smartphones()
        {
            return View();
        }
        [HttpPost]
        public JsonResult getPname(Product_Model p)
        {
            con.Open();
            string query = "select pname,image,Chipset,Size,Memory,MainCamera,FrontCamera,Battery,price,OS,Weight from Products where pname='"+p.pname+"' and ptype='"+p.ptype+"' ";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            p.image = dt.Rows[0]["image"].ToString();
            p.Chipset = dt.Rows[0]["Chipset"].ToString();
            p.Size = dt.Rows[0]["Size"].ToString();
            p.Memory = dt.Rows[0]["Memory"].ToString();
            p.MainCamera = dt.Rows[0]["MainCamera"].ToString();
            p.FrontCamera = dt.Rows[0]["FrontCamera"].ToString();
            p.Battery = dt.Rows[0]["Battery"].ToString();
            p.price = Convert.ToInt32(dt.Rows[0]["price"]);
            p.OS= dt.Rows[0]["OS"].ToString();
            p.Weight= dt.Rows[0]["Weight"].ToString();
            return Json(p, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetSmartphonesSearch(string term)
        {
            con.Open();
            string query = "select pname from Products where pname Like '" + term + "%' and ptype='Smartphones' ";
            SqlDataAdapter data = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            List<String> productList = new List<String>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string pname= dt.Rows[i]["pname"].ToString();
                productList.Add(pname);
            }
            return Json(productList,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTabletsSearch(string term)
        {
            con.Open();
            string query = "select pname from Products where pname Like '" + term + "%' and ptype='Tablets' ";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            List<String> productList = new List<String>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string pname = dt.Rows[i]["pname"].ToString();
                productList.Add(pname);
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLaptopsSearch(string term)
        {
            con.Open();
            string query = "select pname from Products where pname Like '" + term + "%' and ptype='Laptops' ";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);
            List<String> productList = new List<String>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string pname = dt.Rows[i]["pname"].ToString();
                productList.Add(pname);
            }
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Laptops()
        {
            return View();
        }

        public ActionResult Tablets()
        {
            return View();
        }
    }
}