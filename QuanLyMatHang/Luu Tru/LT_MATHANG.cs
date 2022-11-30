using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace _QuanLyMatHang
{
    public class LT_MATHANG
    {
        private const string FILEPATH = "C:\\Users\\admin\\source\\repos\\QuanLyMatHang\\mathang.txt";
        public static List<MATHANG> DocDanhSach()
        {
            List<MATHANG> dsMH = new List<MATHANG>();
            StreamReader reader = new StreamReader(FILEPATH);
             while(!reader.EndOfStream)
            {
               string s = reader.ReadLine();
               string[] M = s.Split(',');
                MATHANG mh = new MATHANG();
                mh.maHang = M[0];
                mh.tenHang = M[1];
                mh.congTySX = M[2];
                mh.loaiHang = M[3];
                mh.ngaySX = DateTime.ParseExact(M[4], "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                mh.hanDung = DateTime.ParseExact(M[5], "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                mh.donGia = int.Parse(M[6]);
                mh.soLuongHang = int.Parse(M[7]);
                mh.tongGia = mh.donGia * mh.soLuongHang;
                dsMH.Add(mh);
            }
            reader.Close();
            return dsMH;
        }
        public static void ThemMatHang (MATHANG mh)
        {
            var dsmh = DocDanhSach();
            dsmh.Add(mh);
            LuuDanhSach(dsmh);
        }

        public static void LuuDanhSach(List<MATHANG> dsmh)
        {
            StreamWriter writer = new StreamWriter(FILEPATH);
            foreach(var mh in dsmh)
            {
                var date = mh.ngaySX.ToString("MM/dd/yyyy hh:mm:ss tt");
                var handung = mh.hanDung.ToString("MM/dd/yyyy hh:mm:ss tt");
                writer.WriteLine($"{mh.maHang},{mh.tenHang},{mh.congTySX},{mh.loaiHang},{date},{handung},{mh.donGia},{mh.soLuongHang}");
            }
            writer.Close();
        }

        public static void XoaMatHang(string maHang)
        {
            var dsmh = DocDanhSach();
            foreach (var mh in dsmh)
            {
                if (mh.maHang == maHang)
                {
                    dsmh.Remove(mh);
                    break;
                }
            }
            LuuDanhSach(dsmh);
        }
    }
}