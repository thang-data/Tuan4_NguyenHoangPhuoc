using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenHoangPhuoc1.Models;

namespace Tuan4_NguyenHoangPhuoc1.Controllers
{
    public class GioHangController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public List<GioHang> Laygiohang()
        {
            List<GioHang> lstGiohang = Session["GioHang"] as List<GioHang>;
            if (lstGiohang == null )
            {
                lstGiohang = new List<GioHang>();
                Session["GioHang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGioHang (int id , string strURL)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.Find(n => n.masach == id);
            if (sanpham == null)
            {
                sanpham = new GioHang(id);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int Tongsoluong()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Sum(n => n.iSoluong);
            }
            return tsl;
        }
        private int TongsoluongSanpham()
        {
            int tsl = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tsl = lstGiohang.Count;
            }
            return tsl;
        }
        private double Tongtien()
        {
            double tt = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                tt = lstGiohang.Sum(n => n.dThanhtien);
            }
            return tt;
        }
        public ActionResult GioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            ViewBag.Tongsoluongsanpham = TongsoluongSanpham();
            return View(lstGiohang);
        }
        public ActionResult GioHangPartial()
        {
            List<GioHang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            ViewBag.Tongsoluongsanpham = TongsoluongSanpham();
            return PartialView();
        }
        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.masach == id);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.masach == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<GioHang> lstGiohang = Laygiohang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.masach == id);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(collection["txtSolg"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("GioHang");
        }
    }
}
 