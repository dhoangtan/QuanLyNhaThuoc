using QuanLyNhaThuoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.ViewModel
{
    public class ViewHoaDonModel
    {
        public HoaDon hoaDon { get; set; }
        public List<ChiTietHoaDon> list { get; set; }
    }
}