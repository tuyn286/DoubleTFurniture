using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoubleTFurniture.Models
{
    public class Product
    {
        public int masanpham { get; set; }
        public string tensanpham { get; set; }
        public string mota { get; set; }
        public int gia { get; set; }
        public string mau { get; set; }
        public string chatlieu { get; set; }
        public string hinhanh { get; set; }
        public int madanhmuc { get; set; }
        public Product()
        {

        }

        public Product(int ma, string ten, string mota, int gia, string mau, string cl, string anh, int madm)
        {
            masanpham = ma;
            tensanpham = ten;
            this.mota = mota;
            this.gia = gia;
            this.mau = mau;
            chatlieu = cl;
            hinhanh = anh;
            madanhmuc = madm;
        }
    }
}