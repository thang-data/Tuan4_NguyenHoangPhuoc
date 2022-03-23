using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenHoangPhuoc1.Models;

namespace Tuan4_NguyenHoangPhuoc1.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult DangKy(FormCollection collection,KhachHang kh)
        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnhap   "];
            var matkhau = collection["matkhau"];
            var matkhauXacnhan = collection["matkhauXacnhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var Ngaysinh = String.Format("{0:MM/dd/yyyy}",collection["Ngaysinh"]);
            
            if (String.IsNullOrEmpty(matkhauXacnhan))
            {
                ViewData["NhapMKXN"] = "Phai nhap mat khau xac nhan ";

            }
            else
            {
                if(!matkhau.Equals(matkhauXacnhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mat khau va mat khau xac minh phai giong nhau";

                }
                else
                {
                    kh.hoten = hoten;
                    kh.tendangnhap = tendangnhap;
                    kh.matkhau = matkhau;
                    kh.email = email;
                    kh.diachi = diachi;
                    kh.dienthoai = dienthoai;
                    kh.ngaysinh = DateTime.Parse(Ngaysinh);

                    data.KhachHang.InsertOnSubmit(kh);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["matkhau"];
            KhachHang kh = data.KhachHang.SingleOrDefault(n => n.tendangnhap == tendangnhap && n.matkhau == matkhau);   
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công ";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Bạn sai tên đăng nhập / mật khẩu ";
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}