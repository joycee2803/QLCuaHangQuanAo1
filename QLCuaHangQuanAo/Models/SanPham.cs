using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLCuaHangQuanAo.Models
{
    [Table("SanPhams")]
    public class SanPham
    {
        [Key]
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string GiaBan { get; set; }
        public string NgayNhapKho { get; set; }
        public string NgayBanRa { get; set; }
    }
}