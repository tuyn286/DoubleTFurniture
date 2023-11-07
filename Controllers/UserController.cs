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

        public ActionResult Index()
        {
            List<Category> categories = categoryDAO.getAll();
            List<Product> products = productDAO.getAll();
            var data = new Tuple<List<Category>, List<Product>>(categories, products);
            return View(data);
        }
        public ActionResult details(int masp)
        {
            var sanpham = productDAO.getProductById(masp);
            return View(sanpham);
        }
    }
}