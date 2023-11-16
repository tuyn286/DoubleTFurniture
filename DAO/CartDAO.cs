using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.DAO
{
    public class CartDAO
    {
        string path = "D:/xml/DoubleTFurniture/App_Data/xml/GioHang.xml";
        public XmlDocument doc = new XmlDocument();
        private UserDAO userDAO = new UserDAO();
        private ProductDAO productDAO = new ProductDAO();
        public CartDAO()
        {
            doc.Load(path);
        }
        public int getIdCartByIdUser(int idUser)
        {
            int idCart=0;
            XmlNodeList giohang = doc.SelectNodes("GioHangs/giohang");
            foreach (XmlElement e in giohang)
            {
                if (Int32.Parse(e.ChildNodes[1].InnerText) == idUser)
                {
                    idCart = Int32.Parse(e.ChildNodes[0].InnerText);
                }
            }
            return idCart;
        }
        public List<Product> getProductIdByIdCart(int idCart)
        {
            XmlNodeList cartPro = doc.SelectNodes("GioHangs/giohang[magiohang='"+idCart+"']/giohangsanphams/giohangsanpham");
            List<Product> products = new List<Product>();
            foreach(XmlElement e in cartPro)
            {
                if (Int32.Parse(e.ChildNodes[2].InnerText) == idCart)
                {
                    Product product = productDAO.getProductById(Int32.Parse(e.ChildNodes[1].InnerText));
                    products.Add(product);
                }
            }
            return products;

        }
        public List<Product> getProducts(string username)
        {
            List<Product> products = new List<Product>();
            int idUser = userDAO.getIdByUsername(username);
            int idCart = this.getIdCartByIdUser(idUser);
            products = this.getProductIdByIdCart(idCart);
            return products;
        }
        public void deleteProduct(int masp,string username)
        {
            int idUser = userDAO.getIdByUsername(username);
            int idCart = this.getIdCartByIdUser(idUser);
            XmlNodeList list = doc.SelectNodes("GioHangs/giohang[magiohang='" + idCart + "']/giohangsanphams/giohangsanpham");
            foreach(XmlElement e in list)
            {
                if (Int32.Parse(e.ChildNodes[1].InnerText) == masp)
                {
                    e.ParentNode.RemoveChild(e);
                    continue;
                }
            }
            doc.Save(path);
        }
        public void addProduct(int masp, string username)
        {
            int idUser = userDAO.getIdByUsername(username);
            int idCart = this.getIdCartByIdUser(idUser);
            XmlNode node = doc.SelectSingleNode("GioHangs/giohang[magiohang='" + idCart + "']/giohangsanphams");
            XmlElement giohang = doc.CreateElement("giohangsanpham");

            XmlElement maghsp = doc.CreateElement("maghsp");
            maghsp.InnerText = Guid.NewGuid().ToString();
            giohang.AppendChild(maghsp);

            XmlElement masanpham = doc.CreateElement("masanpham");
            masanpham.InnerText = masp.ToString();
            giohang.AppendChild(masanpham);

            XmlElement magiohang = doc.CreateElement("magiohang");
            magiohang.InnerText = idCart.ToString();
            giohang.AppendChild(magiohang);

            node.AppendChild(giohang);

            doc.Save(path);

        }
    }
}