using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BaiTap.Models;
using System.Data.Entity;
using System.Text;
namespace BaiTap.Demo
{
    public partial class ExEagerLoading : System.Web.UI.Page
    {
        // Khi Lazy Loading Enadled là False

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                List<SanPham> items = db.SanPhams
                    .Include("Loai")
                    .ToList();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // đọc thông tin của các sanpham co loai id =3 bao gom thong tin ve loai, chung loai
            using (var db = new DienMayDbContext())
            {
                List<SanPham> items = db.SanPhams
                    .Include("Loai")
                    .Include("Loai.ChungLoai")
                    .Where(p => p.LoaiID == 3)//phai truoc include
                    .ToList();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                // đọc thông tin của các sanpham co loai id =3 bao gom thong tin ve loai, chung loai
                List<SanPham> items = db.SanPhams
                    .Where(p => p.LoaiID == 3)
                    .Include(p=>p.Loai)
                    .Include(p=>p.Loai.ChungLoai)
                    .ToList();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                // đọc thông tin của các sanpham co loai id =3 bao gom thong tin ve loai, chung loai
                SanPham items = db.SanPhams
                    .Include(p => p.Loai)
                    .SingleOrDefault(p => p.SanPhamID == 8);
                SanPham items2 = db.SanPhams
                    .Where(p => p.SanPhamID == 8)
                    .Include(p => p.Loai)
                    .SingleOrDefault();

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                Loai item = db.Loais
                    .Include("ChungLoai")
                    .Include("SanPhams")
                    .Include("SanPhams.HoaDonChiTiets")
                    .Include("SanPhams.HoaDonChiTiets.HoaDon")
                    .SingleOrDefault(p => p.LoaiID == 1);
                string tenloai = item.Ten;
                string tenChungLoai = item.ChungLoai.Ten;
                int tongsp = item.SanPhams.Count;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<h3>{0}</h3>", item.Ten);
                foreach(var sp in item.SanPhams)
                {
                    sb.AppendFormat("{0}-{1}/br", sp.SanPhamID, sp.Ten);
                }

                lbKetQua.Text = sb.ToString();
                literalKetQua.Text=sb.ToString();
                
            }
        }
    }
}