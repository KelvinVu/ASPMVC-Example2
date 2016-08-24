using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BaiTap.Models;
namespace Baitap.Demo
{
    public partial class ExSelectMany : System.Web.UI.Page
    {
        
        protected void btnViDu1_Click(object sender, EventArgs e)
        {// Difference between Select and SelectMany in LINQ

            using (DienMayDbContext db = new DienMayDbContext())
            {
                // Select: Trả về 2 tập hợp lồng nhau (phải dùng 2 vòng for để truy xuất)
                var ds1 = db.ChungLoais
                            .Select(p => p.Loais)
                            .ToList();

                // SelectMany: Trả về 1 tập hợp
                var ds2 = db.ChungLoais
                            .SelectMany(p => p.Loais)
                            .ToList();
            }

        }

        protected void btnViDu2_Click(object sender, EventArgs e)
        {// SelectMany:
            using (DienMayDbContext db = new DienMayDbContext())
            {
                // Đọc thông tin gồm ChungLoaiID,TenChungLoai, TenLoai. 
                // (Chỉ những chủng loại có thông tin về loại)
                var items = db.ChungLoais
                              .SelectMany(cl => cl.Loais
                                                  .Select(l => new
                                                  {
                                                      cl.ChungLoaiID,
                                                      TenChungLoai = cl.Ten,
                                                      TenLoai =  l.Ten
                                                  }))
                              .OrderBy(k => k.ChungLoaiID)
                              .ToList();
                gvwKetQua.DataSource = items;
                gvwKetQua.DataBind();
            }
        }

        protected void btnViDu3_Click(object sender, EventArgs e)
        {// SelectMany:
            using (DienMayDbContext db = new DienMayDbContext())
            {
                // Đọc thông tin gồm ChungLoaiID,TenChungLoai, TenLoai. 
                // (Kể cả chủng loại chưa có thông tin về loại - DefaultIfEmpty)
                var items = db.ChungLoais
                              .SelectMany(cl => cl.Loais
                                                  .DefaultIfEmpty()
                                                  .Select(l => new
                                                  {
                                                      cl.ChungLoaiID,
                                                      TenChungLoai = cl.Ten,
                                                      TenLoai = l == null ? "" : l.Ten
                                                  }))
                              .OrderBy(k => k.ChungLoaiID)
                              .ToList();
                gvwKetQua.DataSource = items;
                gvwKetQua.DataBind();
            }
        }

        protected void btnViDu4_Click(object sender, EventArgs e)
        {
            // SelectMany:
            // Khi các thực thể không có quan hệ trong EDM 
            // Sử dụng Where để kết Chủ đề với Sách 
            using (BooksDbContext db = new BooksDbContext())
            {
                int donGia = 100000;
                var query = db.ChuDes
                              .SelectMany(cd => db.Saches
                                                  .Where(s => (cd.MaChuDe == s.MaChuDe)
                                                        && s.GiaBan < donGia && s.NgayCapNhat >= new DateTime(2012, 11, 17))
                                                  .Select(s => new
                                                  {
                                                      cd.MaChuDe,
                                                      cd.TenChuDe,
                                                      s.SachID,
                                                      s.TenSach,
                                                      s.GiaBan,
                                                      s.NgayCapNhat
                                                  })
                                         )
                              .OrderBy(k => k.NgayCapNhat);
                var items = query.ToList();
                gvwKetQua.DataSource = items;
                gvwKetQua.DataBind();
            }

        }
        protected void btnViDu5_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                // Lấy các sản phẩm thuộc loại nokia có giá bán cao nhất.
                //int max = db.SanPhams
                //         .Where(p => p.Loai.Ten.Contains("nokia"))
                //         .Max(x => x.GiaBan);
                //var ds1 = db.SanPhams
                //             .Where(p => p.Loai.Ten.Contains("nokia") && p.GiaBan == max)
                //             .Select(p => new { TenSP = p.Ten, LoaiSP = p.Loai.Ten, p.SoLuong, p.GiaBan, p.MoTa })
                //            .ToList();

                var ds2 = db.Loais
                            .Where(l => l.Ten.Contains("nokia"))
                            .SelectMany(l => l.SanPhams
                                            .Where(s => s.GiaBan == l.SanPhams.Max(x => x.GiaBan))
                                            .Select(p => new { TenSP = p.Ten, LoaiSP = l.Ten, p.SoLuong, p.GiaBan, p.MoTa }))
                           .ToList();

                gvwKetQua.DataSource = ds2;
                gvwKetQua.DataBind();
            }

        }
        #region  So sánh khác giữa Select và SelectMany



        protected void btnViDu6_Click(object sender, EventArgs e)
        { // Select
            // Giống Ví dụ 2, nhưng dùng Select sẽ trả về tập hợp con (lồng 2 tập hợp)
            using (DienMayDbContext db = new DienMayDbContext())
            {
                var items = db.ChungLoais
                              .Select(cl => cl.Loais
                                                .Select(l => new
                                                {
                                                    cl.ChungLoaiID,
                                                    TenChungLoai = cl.Ten,
                                                    TenLoai = l.Ten
                                                }))
                              .ToList();
                //gvwKetQua.DataSource = items; //--> Error
                //gvwKetQua.DataBind();
            }
        }
        protected void btnViDu7_Click(object sender, EventArgs e)
        {
        // Select
            // Tương tự Ví dụ 2, nhưng đảo thực thể truy vấn chính là Loais thay vì ChungLoais
            using (DienMayDbContext db = new DienMayDbContext())
            {
                // Đọc thông tin gồm ChungLoaiID,TenChungLoai, TenLoai. 
                // (chỉ những chủng loại có thông tin về loại)
                var items = db.Loais
                                .Select(l => new { l.ChungLoaiID, TenChungLoai = l.ChungLoai.Ten, TenLoai = l.Ten })
                                .OrderBy(l => l.ChungLoaiID)
                                .ToList();

                gvwKetQua.DataSource = items;
                gvwKetQua.DataBind();
            }
        }
        #endregion

       
    }
}