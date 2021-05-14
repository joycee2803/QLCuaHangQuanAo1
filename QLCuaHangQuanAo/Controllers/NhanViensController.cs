using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLCuaHangQuanAo.Models;
using QLCuaHangQuanAo.Models.ExcelProcess;
namespace QLCuaHangQuanAo.Controllers
{
    public class NhanViensController : Controller
    {
        private QLCuaHangQuanAoDbContext db = new QLCuaHangQuanAoDbContext();
        ReadExcel excel = new ReadExcel();

        // GET: NhanViens
        public ActionResult Index()
        {
            return View(db.NhanViens.ToList());
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,TenNhanVien,SoDienThoai,DiaChi,SoCCCD")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,TenNhanVien,SoDienThoai,DiaChi,SoCCCD")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //dat ten cho file
            string _FileName = "NhanVien.xls";
            //duong dan luu file
            string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);
            //luu file len server
            file.SaveAs(_path);
            // đọc dữ liệu từ file Excel
            DataTable dt = excel.ReadDataFromExcelFile(_path);
            //CopyDataByBulk(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien nv = new NhanVien();
                nv.MaNhanVien = dt.Rows[i][0].ToString();
                nv.TenNhanVien = dt.Rows[i][1].ToString();
                nv.SoDienThoai = dt.Rows[i][2].ToString();
                nv.DiaChi = dt.Rows[i][3].ToString();
                nv.SoCCCD = dt.Rows[i][4].ToString();
                db.NhanViens.Add(nv);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //doc file excel tra ve du lieu dang datatable
        
        private void CopyDataByBulk(DataTable dt)
        {
            //lay ket noi voi database luu trong file webconfig
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["QLCuaHangQuanAoDbContext"].ConnectionString);
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "NhanViens";
            bulkcopy.ColumnMappings.Add(0, "MaNhanVien");
            bulkcopy.ColumnMappings.Add(1, "TenNhanVien");
            bulkcopy.ColumnMappings.Add(2, "SoDienThoai");
            bulkcopy.ColumnMappings.Add(3, "DiaChi");
            bulkcopy.ColumnMappings.Add(4, "SoCCCD");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }

        [HttpPost]
        public ActionResult UploadExcelFile(HttpPostedFileBase file)
        {
            try
            {
                //upload file thanh cong va file co du lieu
                if (file.ContentLength > 0)
                {
                    //Your code
                }
            }
            catch (Exception ex)
            {
                //neu upload file that bai
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private class OleDbDataAdapter
        {
            internal void Fill(DataSet ds)
            {
                throw new NotImplementedException();
            }
        }

        private class OleDbCommand
        {
        }

        private class OleDbConnection
        {
            public OleDbConnection(string connectionString)
            {
                ConnectionString = connectionString;
            }

            public string ConnectionString { get; }

            internal void Close()
            {
                throw new NotImplementedException();
            }

            internal void Open()
            {
                throw new NotImplementedException();
            }
        }

        private class OleDbataAdapter
        {
        }
    }

    internal class Path
    {
        internal static string Combine(string v, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
