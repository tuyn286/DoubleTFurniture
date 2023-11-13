using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoubleTFurniture.Models;
using System.Xml.Linq;
using System.Xml;

namespace DoubleTFurniture.DAO
{
    public class UserDAO
    {
        string path = "D:/xml/DoubleTFurniture/App_Data/xml/NguoiDung.xml";
        public XmlDocument doc = new XmlDocument();
        public UserDAO()
        {
            doc.Load(path);
        }
        public List<User> getAll()
        {
            List<User> listU = new List<User>();
            XmlNodeList list = doc.GetElementsByTagName("nguoidung");
            foreach(XmlElement e in list)
            {
                User u = new User();
                u.manguoidung = Int32.Parse(e.ChildNodes[0].InnerText);
                u.tennguoidung = e.ChildNodes[1].InnerText;
                u.tendangnhap = e.ChildNodes[2].InnerText;
                u.matkhau = e.ChildNodes[3].InnerText;
                u.diachi = e.ChildNodes[4].InnerText;

                listU.Add(u);
            }
            return listU;
        }
        public string checkCredential(string username,string password)
        {
            XmlNodeList listUser = doc.GetElementsByTagName("nguoidung");
            foreach(XmlElement e in listUser)
            {
                if(e.ChildNodes[2].InnerText.Equals(username) && e.ChildNodes[3].InnerText.Equals(password))
                {
                    if (username.Equals("admin"))
                    {
                        return "admin";
                    }
                    else
                    {
                        return e.ChildNodes[1].InnerText;
                    }
                }
            }
            return "none";
        }
        public void deleteUsertById(int id)
        {
            XmlNodeList list = doc.SelectNodes("NguoiDungs/nguoidung");
            foreach (XmlElement e in list)
            {
                if (Int32.Parse(e.ChildNodes[0].InnerText) == id)
                {
                    e.ParentNode.RemoveChild(e);
                }
            }
            doc.Save(path);
        }
    }
}