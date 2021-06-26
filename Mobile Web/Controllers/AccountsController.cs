using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobile_Web.Models;
using Mobile_Web.DB.DB_Operations;
using Mobile_Web.DB;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
namespace Mobile_Web.Controllers
{
    public class AccountsController : Controller
    {
        SqlConnection con = new SqlConnection(Connection.ConnectionString);
        UserRepository repo = null;
        public AccountsController()
        {
            repo = new UserRepository();
        }
        // GET: Accounts
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User_Model userinfo)
        {

            if(repo.loginAccount(userinfo))
            {
                FormsAuthentication.SetAuthCookie(userinfo.username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("signin", "Incorrect Username or Password.");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User_Model userinfo)
        {
            if (ModelState.IsValid)
            {
                bool isUserNameAlreadyExists=false;
                con.Open();
                string query = "Select * from Users where username='" + userinfo.username +"'";
                SqlDataAdapter data = new SqlDataAdapter(query, con);
                DataTable dtable = new DataTable();
                data.Fill(dtable);
                if (dtable.Rows.Count >= 1)
                {
                    isUserNameAlreadyExists = true;
                    if (isUserNameAlreadyExists)
                    {
                        ModelState.AddModelError("username", "Sorry username already taken, Try another.");
                        con.Close();
                        return View(userinfo);
                    }
                }
                /*using (var context = new Mobile_WebEntities())
                {
                    var isUserNameAlreadyExists = context.Users.Any(x => x.username == userinfo.username);
                    if(isUserNameAlreadyExists)
                    {
                        ModelState.AddModelError("username","Sorry username already taken, Try another.");
                        return View(userinfo);
                    }
                };*/
                con.Close();
                string username = repo.createAccount(userinfo);

                return RedirectToAction("SignIn");
            }
            else
            {
                return View(userinfo);
            }

        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
    }
}