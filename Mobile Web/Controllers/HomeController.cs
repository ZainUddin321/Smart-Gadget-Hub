using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Mobile_Web.DB;
using System.Dynamic;
using System.Net.Mail;
using System.Net;

namespace Mobile_Web.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection(Connection.ConnectionString);
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Accessories()
        {
            //
            con.Open();
            string query = "select P_id,pname,ptype,price,payment_method,image,rating,Discount from Products where ptype='"+"Smartphones"+"'";
            SqlDataAdapter data = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            data.Fill(dt);

            string query1 = "select P_id,pname,ptype,price,payment_method,image,rating,Discount from Products where ptype='" + "Laptops" + "'";
            SqlDataAdapter data1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            data1.Fill(dt1);

            string query2 = "select P_id,pname,ptype,price,payment_method,image,rating,Discount from Products where ptype='" + "Tablets" + "'";
            SqlDataAdapter data2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            data2.Fill(dt2);

            dynamic mymodel = new ExpandoObject();
            mymodel.Smartphones = dt;
            mymodel.Laptops = dt1;
            mymodel.Tablets = dt2;

            //

            ViewBag.DuplicateRecord = TempData["DuplicateRecord"];
            return View(mymodel);
        }

        public ActionResult Support()
        {
            return View();
        }
        [HttpPost]
        public ViewResult ContactUs(string name, string email, string subject, string message)
        {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("estartup@gmail.com",name);
                    var receiverEmail = new MailAddress("estartup@gmail.com", "EStartUp");
                    var password = "PasswordHere";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = email+"\n\n"+body
                    })
                    {
                        smtp.Send(mess);
                    }
                }
            return View("Support");
        }
    }
}