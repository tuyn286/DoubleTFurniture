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
        public XmlDocument doc = new XmlDocument();
        public UserDAO()
        {
            doc.Load("D:/xml/DoubleTFurniture/App_Data/xml/NguoiDung.xml");
        }
        public List<User> getAll()
        {
            return null;
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
    }
}