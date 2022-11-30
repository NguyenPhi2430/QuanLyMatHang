
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace _QuanLyMatHang
{
    public class XL_DATETIMEFORMAT
    {
        public static DateTime FormatStringToDateTime (string s)
        {
            DateTime kq = DateTime.ParseExact(s,"MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            return kq;
        }

        public static string ThemThoiGian(string s)
        {
            string ThoiGianThemVao = " 12:00:00 AM";
            string kq = s;
            if (!s.Contains(ThoiGianThemVao))
            {
                kq = s + ThoiGianThemVao;
            }
            return kq;
        }
    }
}