using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoubleTFurniture.DAO;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.Controllers
{
    public class UserController : Controller
    {
        CategoryDAO categoryDAO = new CategoryDAO();
        ProductDAO productDAO = new ProductDAO();
        UserDAO userDAO = new UserDAO();
        CartDAO cartDAO = new CartDAO();

        public ActionResult Index()
        {
            List<Category> categories = categoryDAO.getAll();
            List<Product> products = productDAO.getAll();
            var prdcate = new Tuple<List<Category>, List<Product>>(categories, products);
            return View(prdcate);
        }
        public ActionResult details(int masp)
        {
            var sanpham = productDAO.getProductById(masp);
            return View(sanpham);
        }
        public ActionResult shop()
        {
            List<Product> products = productDAO.getAll();


            return View(products);

        }
        public ActionResult loginForm()
        {
            return View();
        }
        public ActionResult loginHandle(string username,string password)
        {
            string cred = userDAO.checkCredential(username, password);
            if (cred.Equals("admin"))
            {
                HttpCookie cookie = new HttpCookie("loginKey");
                cookie.Value = cred;
                Response.Cookies.Add(cookie);
                return Redirect("~/Admin/index");
            }else if (cred.Equals("none"))
            {
                return Redirect("~/User/Index");
            }
            else
            {
                HttpCookie cookie = new HttpCookie("loginKey");
                cookie.Value = cred;
                Response.Cookies.Add(cookie);
                return Redirect("~/User/Index");
            }
        }
        public ActionResult cart()
        {
            List<Product> products = new List<Product>();
            string savedUsername = Request.Cookies["loginKey"]?.Value;
            if(savedUsername != null)
            {
                products = cartDAO.getProducts(savedUsername);
            } 
            return View(products);
        }
        public ActionResult logOut()
        {
            if (Request.Cookies["loginKey"] != null)
            {
                Response.Cookies["loginKey"].Expires = DateTime.Now.AddDays(-1);
            }
            return Redirect("~/User/index");
        }

        public ActionResult deleteProCart(int masp)
        {
            string savedUsername = Request.Cookies["loginKey"]?.Value;
            cartDAO.deleteProduct(masp, savedUsername);
            return Redirect("~/User/cart");
        }

        public ActionResult addProCart(int masp)
        {
            string savedUsername = Request.Cookies["loginKey"]?.Value;
            cartDAO.addProduct(masp, savedUsername);
            return Redirect("~/User/shop");
        }
    }
}