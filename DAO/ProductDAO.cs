using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.DAO
{
    public class ProductDAO
    {
        string path = "D:/xml/DoubleTFurniture/App_Data/xml/Product.xml";
        public XmlDocument document = new XmlDocument();
        public ProductDAO()
        {
            document.Load(path);
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
            foreach (XmlElement e in list)
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
        public void deleteProductById(int id)
        {
            XmlNodeList list = document.SelectNodes("Product/sanpham");
            foreach (XmlElement e in list)
            {
                if (Int32.Parse(e.ChildNodes[0].InnerText) == id)
                {
                    e.ParentNode.RemoveChild(e);
                }
            }
            document.Save(path);
        }
        public void editProduct(Product product)
        {
            XmlNodeList list = document.SelectNodes("Product/sanpham");
            foreach (XmlElement e in list)
            {
                if (Int32.Parse(e.ChildNodes[0].InnerText) == product.masanpham)
                {
                    e.ChildNodes[1].InnerText = product.tensanpham;
                    e.ChildNodes[2].InnerText = product.mota;
                    e.ChildNodes[3].InnerText = product.gia.ToString();
                    e.ChildNodes[4].InnerText = product.mau;
                    e.ChildNodes[5].InnerText = product.chatlieu;
                    e.ChildNodes[6].InnerText = product.hinhanh;
                    e.ChildNodes[7].InnerText = product.madanhmuc.ToString();
                }
            }
            document.Save(path);
        }
        public void addProduct(Product product)
        {
            XmlElement sanpham = document.CreateElement("sanpham");
            /*ma san pham*/
            XmlElement ma = document.CreateElement("masanpham");
            ma.InnerText = product.masanpham.ToString();
            sanpham.AppendChild(ma);
            /*ten san pham*/
            XmlElement ten = document.CreateElement("tensanpham");
            ten.InnerText = product.tensanpham;
            sanpham.AppendChild(ten);
            /*mo ta san pham*/
            XmlElement mota = document.CreateElement("mota");
            mota.InnerText = product.mota;
            sanpham.AppendChild(mota);
            /*gia san pham*/
            XmlElement gia = document.CreateElement("gia");
            gia.InnerText = product.gia.ToString();
            sanpham.AppendChild(gia);
            /*mau san pham*/
            XmlElement mau = document.CreateElement("mau");
            mau.InnerText = product.mau;
            sanpham.AppendChild(mau);
            /*chat lieu san pham*/
            XmlElement cl = document.CreateElement("chatlieu");
            cl.InnerText = product.chatlieu;
            sanpham.AppendChild(cl);
            /*hinh anh san pham*/
            XmlElement ha = document.CreateElement("hinhanh");
            ha.InnerText = product.tensanpham;
            sanpham.AppendChild(ha);
            /*ma danh muc*/
            XmlElement madm = document.CreateElement("madanhmuc");
            madm.InnerText = product.madanhmuc.ToString();
            sanpham.AppendChild(madm);

            XmlNode root = document.SelectSingleNode("/Product");
            root.AppendChild(sanpham);

            document.Save(path);
        }

    }
}