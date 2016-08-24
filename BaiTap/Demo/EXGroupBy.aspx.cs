using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;
using System.Text;

namespace BaiTap.Demo
{
    public partial class EXGroupBy : System.Web.UI.Page
    {
        DienMayDbContext db = new DienMayDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVd1_Click(object sender, EventArgs e)
        {
            // thống kê theo nhóm
            // gom nhóm dữ liệu theo xuatxu đếm tổng số sản phẩm, giá bán cao nhất
            var item = db.SanPhams
                .GroupBy(p => p.XuatXu)
                .Select(p => new { XuatXu = p.Key == null ? "chưa cập nhật" : p.Key, TongSanPham = p.Count(), maxGiaBan = p.Max(x => x.GiaBan) })
                .ToList();
            grv1.DataSource = item;
            grv1.DataBind();
        }

        protected void btnVd2_Click(object sender, EventArgs e)
        {
            var item = db.Loais
                .GroupBy(p => new { p.ChungLoaiID,p.ChungLoai.Ten })
                .Select(p => new { p.Key.ChungLoaiID,TenChungLoai=p.Key.Ten,TongSoLoai=p.Count()  })
                .ToList();
            grv1.DataSource = item;
            grv1.DataBind();
        }

        protected void btnVd3_Click(object sender, EventArgs e)
        {
            // thống kê tổng số lượng sản phẩm, giá bán cao nhất của từng loại
            // gom nhóm  dữ liệu theo loaiid,tên loại tính tổng số lượng l=tồn  của sản phẩm, giá bán cao nhất
            var item = db.SanPhams
                .GroupBy(p => new { p.Loai.LoaiID,p.Loai.Ten})
                .Select(p => new { p.Key.LoaiID,p.Key.Ten,TongSoLuong=p.Sum(x=>x.SoLuong),MaxGiaBan=p.Max(x=>x.GiaBan)})
                .ToList();
            grv1.DataSource = item;
            grv1.DataBind();
        }

        protected void btnVd4_Click(object sender, EventArgs e)
        {
            // thống kê số lượng của từng loại kể cả loại chưa có sản phẩm
            var item = db.Loais
                .Select(p => new { p.LoaiID,p.Ten,TongSoLuong=(p.SanPhams.Count==0)?0:p.SanPhams.Sum(s=>s.SoLuong)})
                .ToList();
            grv1.DataSource = item;
            grv1.DataBind();
        }

        protected void btnVd5_Click(object sender, EventArgs e)
        {
            // liệt kê thông tin Xuatxu tổng số sản phẩm, giá bán , giá bán cao nhất, theo từng xuất xứ kể cả thông tin chi tiết vế sản phẩm
            // chỉ lấy những sản phẩm có xuất xứ
            var groupitems = db.SanPhams
                .Where(p=>p.XuatXu!=null)
                .GroupBy(p => p.XuatXu)
                .Select(p => new { XuatXu=p.Key, TongSanPham=p.Count(),maxGiaBan=p.Max(x=>x.GiaBan),ChiTiet=p})
                .ToList();
            StringBuilder sb = new StringBuilder();
            sb.Append("<ol>");
            foreach(var groupitem in groupitems)
            {
                sb.AppendFormat("<li>xuất xứ:{0}-Tổng sản phẩm:{1}</li>", groupitem.XuatXu, groupitem.TongSanPham);
                sb.AppendLine("<ul>");
                foreach(var item in groupitem.ChiTiet)
                {
                    sb.AppendFormat("<li>{0}-{1}</li>", item.SanPhamID, item.Ten);
                }
                sb.AppendLine("</ul>");
            }
            sb.AppendLine("/ol");
            ketqua.Text = sb.ToString();
        }
    }
}