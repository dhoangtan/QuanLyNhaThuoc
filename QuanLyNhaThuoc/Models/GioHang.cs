using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public ApplicationUser NguoiDung { get; set; }
        public string Id { get; set; }
        [Required]
        public DateTime NgayLap { get; set; }
        public string DiaChi { get; set; }
    }
}