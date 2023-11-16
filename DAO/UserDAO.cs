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
            XmlNodeList list = doc.SelectNodes("NguoiDung/nguoidung");
            foreach (XmlElement e in list)
            {
                if (Int32.Parse(e.ChildNodes[0].InnerText) == id)
                {
                    e.ParentNode.RemoveChild(e);
                }
            }
            doc.Save(path);
        }
        public User getUserById(int id)
        {
            User user = new User();
            XmlNodeList list = doc.GetElementsByTagName("manguoidung");
            foreach(XmlElement e in list)
            {
                if(Int32.Parse(e.InnerText) == id)
                {
                    user.manguoidung= Int32.Parse(e.ParentNode.ChildNodes[0].InnerText);
                    user.matkhau= e.ParentNode.ChildNodes[2].InnerText; 
                    user.tendangnhap = e.ParentNode.ChildNodes[2].InnerText;
                    user.tennguoidung = e.ParentNode.ChildNodes[2].InnerText;
                    user.diachi = e.ParentNode.ChildNodes[2].InnerText; ;
                }
            }
            return user;
            
        }
        public void addUser(User user)
        {
            XmlElement nguoidung = doc.CreateElement("nguoidung");

            XmlElement manguoidung = doc.CreateElement("manguoidung");
            manguoidung.InnerText = user.manguoidung.ToString();
            nguoidung.AppendChild(manguoidung);

            XmlElement tennguoidung = doc.CreateElement("tennguoidung");
            tennguoidung.InnerText = user.tennguoidung.ToString();
            nguoidung.AppendChild(tennguoidung);

            XmlElement tendangnhap = doc.CreateElement("tendangnhap");
            tendangnhap.InnerText = user.tendangnhap.ToString();
            nguoidung.AppendChild(tendangnhap);

            XmlElement matkhau = doc.CreateElement("matkhau");
            matkhau.InnerText = user.matkhau.ToString();
            nguoidung.AppendChild(matkhau);

            XmlElement diachi = doc.CreateElement("diachi");
            diachi.InnerText = user.diachi.ToString();
            nguoidung.AppendChild(diachi);

            XmlNode root = doc.SelectSingleNode("/NguoiDung");
            root.AppendChild(nguoidung);
            doc.Save(path);



            

        }
        public void editUser(User user)
        {
            XmlNodeList list = doc.SelectNodes("NguoiDung/nguoidung");
            foreach(XmlElement e in list)
            {
                if(Int32.Parse(e.ChildNodes[0].InnerText)==user.manguoidung)
                {
                    e.ChildNodes[1].InnerText = user.tennguoidung;
                    e.ChildNodes[2].InnerText = user.tendangnhap;
                    e.ChildNodes[3].InnerText = user.matkhau;
                    e.ChildNodes[4].InnerText = user.diachi;
                }
            }
            doc.Save(path);
        }
        public int getIdByUsername(string username)
        {
            int id=0;
            XmlNodeList list = doc.SelectNodes("NguoiDung/nguoidung");
            foreach(XmlElement e in list)
            {
                if (e.ChildNodes[1].InnerText.Equals(username))
                {
                    id = Int32.Parse(e.ChildNodes[0].InnerText);
                }
            }
            return id;
        }
    }
}