namespace QLCuaHangQuanAo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_KhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 128),
                        TenKhachHang = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.KhoHangs",
                c => new
                    {
                        MaKho = c.String(nullable: false, maxLength: 128),
                        MaSanPham = c.String(),
                        TenSanPham = c.String(),
                        SoLuong = c.String(),
                    })
                .PrimaryKey(t => t.MaKho);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 128),
                        TenNhanVien = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                        SoCCCD = c.String(),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        MaSanPham = c.String(nullable: false, maxLength: 128),
                        TenSanPham = c.String(),
                        GiaBan = c.String(),
                        NgayNhapKho = c.String(),
                        NgayBanRa = c.String(),
                    })
                .PrimaryKey(t => t.MaSanPham);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPhams");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhoHangs");
            DropTable("dbo.KhachHangs");
        }
    }
}
