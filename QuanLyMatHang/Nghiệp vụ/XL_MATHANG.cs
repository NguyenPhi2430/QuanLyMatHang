using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _QuanLyMatHang
{
    public class XL_MATHANG
    {
        public static List<MATHANG> DocDanhSachMatHang(List<MATHANG> DSMH)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {              
                    kq.Add(mh);           
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangMaHang(string tuKhoa)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if(mh.maHang.Contains(tuKhoa))
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangTenHang(string tuKhoa)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (mh.tenHang.Contains(tuKhoa))
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangCongTySX(string tuKhoa)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (mh.congTySX.Contains(tuKhoa))
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangLoaiHang(string tuKhoa)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (mh.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangTatCa(string tuKhoa)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (mh.maHang.Contains(tuKhoa) || mh.tenHang.Contains(tuKhoa) || mh.congTySX.Contains(tuKhoa) || mh.loaiHang.Contains(tuKhoa))
                {
                    kq.Add(mh);
                }            
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangNgaySX(DateTime? namBD, DateTime? namKT, List<MATHANG> dsmh)
        {
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (namBD <= mh.ngaySX && mh.ngaySX <= namKT)
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static List<MATHANG> TimKiemMatHangBangHanDung(DateTime? namBD, DateTime? namKT, List<MATHANG> dsmh)
        {
            List<MATHANG> kq = new List<MATHANG>();
            foreach (var mh in dsmh)
            {
                if (namBD <= mh.hanDung && mh.hanDung < namKT)
                {
                    kq.Add(mh);
                }
            }
            return kq;
        }

        public static void ThemMatHang(MATHANG mh)
        {
            LT_MATHANG.ThemMatHang(mh);
        }

        public static void XoaMatHang(string maHang)
        {
            LT_MATHANG.XoaMatHang(maHang);
        }

        public static MATHANG DocMatHang(string maHang2)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            foreach (var mh in dsmh)
            {
                if (mh.maHang == maHang2)
                {
                    return mh;
                }
            }
            return TaoMatHang();
        }

        public static MATHANG TaoMatHang()
        {
            MATHANG kq;
            kq.maHang = null;
            kq.tenHang = null;
            kq.congTySX = null;
            kq.donGia = 0;
            kq.ngaySX = new DateTime(2000, 1, 1);
            kq.hanDung = new DateTime(2000, 1, 1);
            kq.loaiHang = null;
            kq.soLuongHang = 0;
            kq.tongGia = 0;
            return kq;
        }

        public static bool SuaMatHang(MATHANG mh)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            for (int i = 0; i < dsmh.Count; i++)
            {
                var m = dsmh[i];
                if (m.maHang == mh.maHang)
                {
                    CapNhatMatHang(ref m, mh);
                    dsmh[i] = m;
                    LT_MATHANG.LuuDanhSach(dsmh);
                    return true;
                }
            }
            return false;
        }

        public static bool SuaSoLuongHang(MATHANG mh)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            for (int i = 0; i < dsmh.Count; i++)
            {
                var m = dsmh[i];
                if (m.maHang == mh.maHang)
                {
                    CapNhatSoLuongHang(ref m, mh);
                    dsmh[i] = m;
                    LT_MATHANG.LuuDanhSach(dsmh);
                    return true;
                }
            }
            return false;
        }

        public static void CapNhatSoLuongHang(ref MATHANG a, MATHANG b)
        {
            a.soLuongHang = b.soLuongHang;
        }

        public static void CapNhatMatHang(ref MATHANG a, MATHANG b)
        {
            a.tenHang = b.tenHang;
            a.congTySX = b.congTySX;
            a.donGia = b.donGia;
            a.hanDung = b.hanDung;
            a.loaiHang = b.loaiHang;
            a.ngaySX = b.ngaySX;
            a.soLuongHang = b.soLuongHang;
        }

        public static int ThongKeMatHang(List<MATHANG> dsmh, string th)
        {
            int thongke = 0;
            foreach (var mh in dsmh)
            {
                if (th == mh.loaiHang)
                {
                    thongke = thongke + mh.soLuongHang;
                }
            }
            return thongke;
        }

        public static int ThongKeHanDung(List<MATHANG> dsmh)
        {
            int thongke = 0;
            foreach (var mh in dsmh)
            {
                if (mh.hanDung < DateTime.Now)
                {
                    thongke = thongke + mh.soLuongHang;
                }
            }
            return thongke;
        }

        public static string KiemTraHopLe (string a)
        {
            List<MATHANG> dsmh = LT_MATHANG.DocDanhSach();
            foreach (var mh in dsmh)
            {
                if (a == mh.maHang)
                {
                    throw new System.ArgumentException("Mã hàng không thể bị trùng với mã hàng trong danh sách mặt hàng");
                }
            }
            return a;
        }

        public static string XuLyDateTime(string dateTime)
        {
            string kq = dateTime + " 12:00:00 AM";
            return kq;
        }
    }
}