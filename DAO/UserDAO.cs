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
        public bool checkCredential(string username,string password)
        {
            return true;
        }
    }
}