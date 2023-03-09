using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class ChiTietHoaDon
    {
        public HoaDon HoaDon { get; set; }
        [Key]
        [Column(Order = 0)]
        public int MaHoaDon { get; set; }
        public SanPham SanPham { get; set; }
        [Key]
        [Column(Order = 1)]
        public string MaSanPham { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public long DonGia { get; set; }
    }
}