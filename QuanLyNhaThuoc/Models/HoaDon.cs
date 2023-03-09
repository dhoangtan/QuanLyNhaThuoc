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
        public string MaNguoiDung { set; get; }
        [Required]
        public DateTime NgayXuat { set; get; }
    }
}