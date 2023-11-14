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
        private CategoryDAO categoryDAO = new CategoryDAO();
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
        public ActionResult editProduct(int masp)
        {
            Product product = productDAO.getProductById(masp);
            List<Category> categories = categoryDAO.getAll();
            var data = new Tuple<Product, List<Category>>(product, categories);
            return View(data);
        }
        public ActionResult editProductHandle(Product product, HttpPostedFileBase hinhanh)
        {
            product.hinhanh = this.upload(hinhanh);
            productDAO.editProduct(product);
            return Redirect("~/Admin/Products");
        }
        public ActionResult addProduct()
        {
            List<Category> categories = categoryDAO.getAll();
            return View(categories);
        }
        public ActionResult addProductHandle(Product product, HttpPostedFileBase hinhanh)
        {
            product.hinhanh = this.upload(hinhanh);
            productDAO.addProduct(product);
            return Redirect("~/Admin/Products");
        }
        public ActionResult deleteUser(int mand)
        {
            userDAO.deleteUsertById(mand);
            return Redirect("~/Admin/Users");
        }
        public string upload(HttpPostedFileBase image)
        {
            string urlImage=null;
            if (image!=null && image.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(image.FileName);
                urlImage = Server.MapPath("~/images/" + fileName);
                image.SaveAs(urlImage);
            }
            return urlImage;
        }
    }
}