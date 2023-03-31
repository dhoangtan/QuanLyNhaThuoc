using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        public ApplicationUser NguoiDung { get; set; }
        public string Id { set; get; }
        [Required]
        public DateTime NgayXuat { set; get; }
        [Required]
        public string TenNguoiDat { get; set; }
        [Required]
        public string SoDienThoai { get; set; }
        [Required]
        public string DiaChi { get; set; }
    }
}