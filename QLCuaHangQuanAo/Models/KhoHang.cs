using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHangQuanAo.Models
{
    [Table("KhoHangs")]
    public class KhoHang
    {
        [Key]
        public string MaKho { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string SoLuong { get; set; }
    }
}