using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobile_Web.DB.DB_Operations;
using Mobile_Web.DB;
using Mobile_Web.Models;
namespace Mobile_Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        UserRepository repo = null;
        public CartController()
        {
            repo = new UserRepository();
        }
        // GET: Cart
        public ActionResult Index()
        {
            using(var context=new Mobile_WebEntities())
            {
                var dbproduct = context.Carts
                    .Select(x => new Cart_Model()
                    {
                        product_id = x.product_id,
                        username = x.username,
                        product_name = x.product_name,
                        product_type = x.product_type,
                        price = x.price,
                        payment_method = x.payment_method,
                        image = x.image
                    }).Where(x=>x.username==User.Identity.Name).ToList();
                return View(dbproduct);
            }
        }
        public ActionResult getProduct(string name,string type, int price, string method, string img)
        {
            using (var context = new Mobile_WebEntities())
            {
                bool isRecordAlreadyExists = context.Carts.Any(x => x.product_name == name && x.username==User.Identity.Name);
                if (isRecordAlreadyExists)
                {
                    TempData["DuplicateRecord"]= "This product is already in your cart.";
                    return RedirectToAction("Accessories", "Home");
                }
            };
            repo.insertData(User.Identity.Name, name, type, price, method, img);
            return RedirectToAction("Index");
        }
        public ActionResult deleteCart(int id)
        {
            repo.deleteData(id);
            return RedirectToAction("Index");
        }
    }
}