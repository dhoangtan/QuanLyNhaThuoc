using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhaThuoc.Models
{
    public class NhaSanXuat
    {
        [Key]
        public int MaNhaSanXuat { get; set; }
        [Required]
        public string TenNhaSanXuat { get; set; }
    }
}