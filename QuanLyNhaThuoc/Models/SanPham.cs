using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class SanPham
    {
        [Key]
        public string MaSanPham { get; set; }
        [Required]
        public string TenSanPham { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        [Required]
        public string MaLoai { get; set; }
        public NhaSanXuat NhaSanXuat { get; set; }
        [Required]
        public int MaNhaSanXuat { get; set; }
        public string ThanhPhanChinh { get; set; }
        public string DoTuoi { get; set; }
        [Required] 
        public string CongDung { get; set;}
        public string DonViTinh { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HSD { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public long GiaBan { get; set; }
        public int LuotMua { get; set; }
        public int LuotXem { get; set; }
    }
}