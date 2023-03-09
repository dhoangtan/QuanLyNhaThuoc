using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class ChiTietGioHang
    {
        public GioHang GioHang { get; set; }
        [Key]
        [Required]
        [Column(Order = 0)]
        public int MaGiohang { get; set; }
    
        public SanPham SanPham { get; set; }
        [Key]
        [Required]
        [Column(Order = 1)]
        public string MaSanPham { get; set; }
        [Required]        
        public int SoLuong { get; set; }
    }
}