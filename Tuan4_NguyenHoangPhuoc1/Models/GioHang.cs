using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tuan4_NguyenHoangPhuoc1.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int masach { get; set; }

        [Display(Name ="Tên Sách ")]
        public string tensach { get; set; }
        [Display(Name = "Ảnh bìa ")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán ")]
        public double giaban { get; set; }
        [Display(Name = "Số lượng  ")]
        public int iSoluong { get; set; }
        [Display(Name = "Thành tiền ")]
        public double dThanhtien
        {
            get { return iSoluong * giaban; }
        }
        public GioHang(int id)
        {
            masach = id;
            Sach sach = data.Saches.Single(n => n.masach == masach);
            tensach = sach.tensach;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            iSoluong = 1 ;
        }
    }
}