using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace _QuanLyMatHang
{
    public class LT_HOADON
    {
        private const string FILEPATH = "C:\\Users\\admin\\source\\repos\\QuanLyMatHang\\hoadon.txt";
        public static List<HOADON> DocDanhSach()
        {
            List<HOADON> dsHD = new List<HOADON>();
            StreamReader reader = new StreamReader(FILEPATH);
             while(!reader.EndOfStream)
            {
               string s = reader.ReadLine();
               string[] M = s.Split(',');
                HOADON hd = new HOADON();
                hd.maHoaDon = M[0];
                hd.maMatHang = M[1];
                hd.tenMatHang = M[2];
                hd.ngayTao = DateTime.ParseExact(M[3], "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                hd.congTySX = M[4];
                hd.loaiHang = M[5];
                hd.soLuongHang = int.Parse(M[6]);
                hd.donGia = int.Parse(M[7]);
                hd.loaiHoaDon = M[8];
                hd.tongGia = hd.donGia * hd.soLuongHang;
                dsHD.Add(hd);
            }
            reader.Close();
            return dsHD;
        }

        public static void ThemHoaDon(HOADON hd, string maHang)
        {
            var dsmh = LT_MATHANG.DocDanhSach();
            foreach (var mh in dsmh)
            {
                if (maHang == mh.maHang)
                {
                    var dshd = DocDanhSach();
                    hd.tenMatHang = mh.tenHang;
                    hd.loaiHang = mh.loaiHang;
                    hd.congTySX = mh.congTySX;
                    hd.donGia = mh.donGia;
                    dshd.Add(hd);
                    LuuDanhSach(dshd);
                }
            }
        }

        public static void LuuDanhSach(List<HOADON> dshd)
        {
            StreamWriter writer = new StreamWriter(FILEPATH);
            foreach (var hd in dshd)
            {
                var Ngay = hd.ngayTao.ToString("MM/dd/yyyy hh:mm:ss tt");
                writer.WriteLine($"{hd.maHoaDon},{hd.maMatHang},{hd.tenMatHang},{Ngay},{hd.congTySX},{hd.loaiHang},{hd.soLuongHang},{hd.donGia},{hd.loaiHoaDon}");
            }
            writer.Close();
        }

        public static void XoaHoaDon(string maHoaDon)
        {
            var dshd = DocDanhSach();
            foreach (var hd in dshd)
            {
                if (hd.maHoaDon == maHoaDon)
                {
                    dshd.Remove(hd);
                    break;
                }
            }
            LuuDanhSach(dshd);
        }
    }
}