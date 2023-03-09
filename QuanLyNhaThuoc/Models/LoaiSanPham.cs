using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class LoaiSanPham
    {
        [Key]
        public string MaLoai { get; set; }
        [Required]
        public string TenLoai { get; set; }
    }
}