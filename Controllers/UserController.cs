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
                cookie["key"] = cred;
                Response.Cookies.Add(cookie);
                return Redirect("~/Admin/index");
            }else if (cred.Equals("none"))
            {
                return Redirect("~/User/Index");
            }
            else
            {
                HttpCookie cookie = new HttpCookie("loginKey");
                cookie["key"] = cred;
                Response.Cookies.Add(cookie);
                return Redirect("~/User/Index");
            }
            return null;
        }
        public ActionResult cart()
        {
            HttpCookie httpCookie = Request.Cookies["loginKey"];
            if(httpCookie != null)
            {
                string savedUsername = httpCookie["key"];

            }
            return Redirect("~/User/Index");
        }
    }
}