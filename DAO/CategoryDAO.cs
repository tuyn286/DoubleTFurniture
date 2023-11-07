using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using DoubleTFurniture.Models;

namespace DoubleTFurniture.DAO
{
    public class CategoryDAO
    {
        public XmlDocument document = new XmlDocument();
        public CategoryDAO()
        {
            document.Load("D:/xml/DoubleTFurniture/App_Data/xml/Category.xml");
        }
        public List<Category> getAll()
        {
            List<Category> categories = new List<Category>();
            XmlNodeList list = document.GetElementsByTagName("danhmuc");
            foreach(XmlElement e in list)
            {
                Category category = new Category();
                category.madanhmuc = Int32.Parse(e.ChildNodes[0].InnerText);
                category.tendanhmuc = e.ChildNodes[1].InnerText;
                categories.Add(category);
            }
            return categories;
        }
    }
}