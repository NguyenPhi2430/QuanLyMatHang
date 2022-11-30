using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _QuanLyMatHang
{
    public class XL_HOADON
    {
        public static List<HOADON> TimKiemHoaDonBangMaHoaDon(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.maHoaDon.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangMaHang(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.maMatHang.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangTenHang(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.tenMatHang.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangCongTy(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.congTySX.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangLoaiHang(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangLoaiHoaDon(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.loaiHoaDon.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemHoaDonBangTatCa(string tuKhoa)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (hd.loaiHoaDon.Contains(tuKhoa) || hd.maHoaDon.Contains(tuKhoa) || hd.maMatHang.Contains(tuKhoa) || hd.tenMatHang.Contains(tuKhoa) || hd.congTySX.Contains(tuKhoa) || hd.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static List<HOADON> TimKiemMatHangBangNgayTao(DateTime? namBD, DateTime? namKT, List<HOADON> dshd)
        {
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                if (namBD <= hd.ngayTao && hd.ngayTao <= namKT)
                {
                    kq.Add(hd);
                }
            }
            return kq;
        }

        public static void ThemHoaDon(HOADON hd, string maHang)
        {
            LT_HOADON.ThemHoaDon(hd, maHang);
        }

        public static void XoaHoaDon(string maHoaDon)
        {
            LT_HOADON.XoaHoaDon(maHoaDon);
        }

        public static HOADON DocHoaDon(string maHoaDon2)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            foreach (var hd in dshd)
            {
                if (hd.maHoaDon == maHoaDon2)
                {
                    return hd;
                }
            }
            return TaoHoaDon();
        }

        public static HOADON TaoHoaDon()
        {
            HOADON kq;
            kq.maHoaDon = null;
            kq.maMatHang = null;
            kq.tenMatHang = null;
            kq.donGia = 0;
            kq.ngayTao = new DateTime(2000, 1, 1);
            kq.loaiHang = null;
            kq.soLuongHang = 0;
            kq.tongGia = 0;
            kq.loaiHoaDon = null;
            kq.congTySX = null;
            return kq;
        }

        public static bool SuaHoaDon(HOADON hd)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            for (int i = 0; i < dshd.Count; i++)
            {
                var h = dshd[i];
                if (h.maHoaDon == hd.maHoaDon)
                {
                    CapNhatHoaDon(ref h, hd);
                    dshd[i] = h;
                    LT_HOADON.LuuDanhSach(dshd);
                    return true;
                }
            }
            return false;
        }

        public static void CapNhatHoaDon(ref HOADON a, HOADON b)
        {
            List<MATHANG> dsmh = new List<MATHANG>();
            XL_MATHANG.DocDanhSachMatHang(dsmh);
            MATHANG mh = new MATHANG();
            a.maMatHang = b.maMatHang;
            mh = XL_MATHANG.DocMatHang(a.maMatHang);
            a.congTySX = mh.congTySX;
            a.tenMatHang = mh.tenHang;
            a.donGia = mh.donGia;
            a.ngayTao = b.ngayTao;
            a.loaiHang = mh.loaiHang;
            a.soLuongHang = b.soLuongHang;
            a.loaiHoaDon = b.loaiHoaDon;
        }

        public static List<HOADON> DocDanhSachHoaDon(List<HOADON> DSHD)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            List<HOADON> kq = new List<HOADON>();
            foreach (var hd in dshd)
            {
                kq.Add(hd);
            }
            return kq;
        }

        public static string KiemTraHopLe(string a)
        {
            List<HOADON> dshd = LT_HOADON.DocDanhSach();
            foreach (var hd in dshd)
            {
                if (a == hd.maHoaDon)
                {
                    throw new System.ArgumentException("Mã hàng không thể bị trùng với mã hàng trong danh sách mặt hàng");
                }
            }
            return a;
        }
    }
}