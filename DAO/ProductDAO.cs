using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.DAO
{
    public class ProductDAO
    {
        public XmlDocument document = new XmlDocument();
        public ProductDAO()
        {
            document.Load("D:/xml/DoubleTFurniture/App_Data/xml/Product.xml");
        }
        public List<Product> getAll()
        {
            List<Product> products = new List<Product>();
            XmlNodeList list = document.GetElementsByTagName("sanpham");
            foreach (XmlElement e in list)
            {
                Product product = new Product();
                product.masanpham = Int32.Parse(e.ChildNodes[0].InnerText);
                product.tensanpham = e.ChildNodes[1].InnerText;
                product.mota = e.ChildNodes[2].InnerText;
                product.gia = Int32.Parse(e.ChildNodes[3].InnerText);
                product.mau = e.ChildNodes[4].InnerText;
                product.chatlieu = e.ChildNodes[5].InnerText;
                product.hinhanh = e.ChildNodes[6].InnerText;
                product.madanhmuc = Int32.Parse(e.ChildNodes[7].InnerText);
                products.Add(product);
            }
            return products;
        }
        public Product getProductById(int id)
        {
            Product product = new Product();
            XmlNodeList list = document.GetElementsByTagName("masanpham");
            foreach(XmlElement e in list)
            {
                if (Int32.Parse(e.InnerText) == id)
                {
                    product.masanpham = Int32.Parse(e.ParentNode.ChildNodes[0].InnerText);
                    product.tensanpham = e.ParentNode.ChildNodes[1].InnerText;
                    product.mota = e.ParentNode.ChildNodes[2].InnerText;
                    product.gia = Int32.Parse(e.ParentNode.ChildNodes[3].InnerText);
                    product.mau = e.ParentNode.ChildNodes[4].InnerText;
                    product.chatlieu = e.ParentNode.ChildNodes[5].InnerText;
                    product.hinhanh = e.ParentNode.ChildNodes[6].InnerText;
                    product.madanhmuc = Int32.Parse(e.ParentNode.ChildNodes[7].InnerText);
                }
            }
            return product;
        }
    }
}