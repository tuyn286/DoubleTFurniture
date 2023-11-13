using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoubleTFurniture.DAO;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.Controllers
{
    public class AdminController : Controller
    {
        private ProductDAO productDAO = new ProductDAO();
        private UserDAO userDAO = new UserDAO();
        public ActionResult Index()
        {
            List<Product> listp = productDAO.getAll();
            List<User> listu = userDAO.getAll();
            ViewBag.pro = listp.Count;
            ViewBag.u = listu.Count;
            return View();
        }

        public ActionResult Products()
        {
            List<Product> list = productDAO.getAll();
            return View(list);
        }

        public ActionResult Users()
        {
            List<User> list = userDAO.getAll();
            return View(list);
        }
        public ActionResult deleteProduct(int masp)
        {
            productDAO.deleteProductById(masp);
            return Redirect("~/Admin/Products");
        }
        public ActionResult deleteUser(int mand)
        {
            userDAO.deleteUsertById(mand);
            return Redirect("~/Admin/Users");
        }
    }
}