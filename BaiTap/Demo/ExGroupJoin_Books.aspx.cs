using BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTap.Demo
{

    // Lưu ý: 
    // Dùng GroupJoin khi 2 thực thể không có relation
    // Nếu có relation giữa các entities với chiến lược tải dữ liệu EagerLoading
    // thì chỉ cần dùng Include không cần GroupJoin
    public partial class ExGroupJoin_Books : System.Web.UI.Page
    {
        BooksDbContext db = new BooksDbContext();

        protected void btnViDu1_Click(object sender, EventArgs e)
        {//// GroupJoin: pt1

            // Thống kê tổng số sách của từng chủ đề. Gồm MaChuDe,TenChuDe, TongSoSach,TongSoLuongBan
            
            var items = db.ChuDes
                          .GroupJoin(db.Saches,              /// inner
                                    cd => cd.MaChuDe,        /// outerKeySelector
                                    sach => sach.MaChuDe,  /// innerKeySelector
                                    (cdResult, sachResult) => new {
                                        cdResult.MaChuDe,
                                        cdResult.TenChuDe,
                                        TongSoSach = sachResult.Count(),
                                        TongSoLuongBan = (sachResult.Count() == 0) ? 0 : sachResult.Sum(p => p.SoLuongBan)
                                    }) /// resultSelector
                          .ToList();

            gvwKetQua.DataSource = items;
            gvwKetQua.DataBind();

        }

        protected void btnViDu2_Click(object sender, EventArgs e)
        {
            // Thống kê tổng số sách của từng chủ đề. Gồm MaChuDe,TenChuDe, TongSoSach,TongSoLuongBan
            // và thông tin chi tiết sách của mỗi chủ đề

            var items = db.ChuDes
                          .GroupJoin(db.Saches,              /// inner
                                    cd => cd.MaChuDe,        /// outerKeySelector
                                    sach => sach.MaChuDe,  /// innerKeySelector
                                    (cdResult, sachResult) => new {
                                        cdResult.MaChuDe,
                                        cdResult.TenChuDe,
                                        TongSoSach = sachResult.Count(),
                                        TongSoLuongBan = (sachResult.Count() == 0) ? 0 : sachResult.Sum(p => p.SoLuongBan),
                                        sachInGroup = sachResult
                                    }) /// resultSelector
                          .ToList();
            var sb = new StringBuilder("<ol>");
            foreach (var cd in items)
            {
                sb.AppendFormat("<li>{0} (Tổng số sách:{1})</li>", cd.TenChuDe,cd.TongSoSach);
                if (cd.sachInGroup.Count() > 0)
                {
                    sb.Append("<ul>");
                    foreach (var s in cd.sachInGroup)
                    {
                        sb.AppendFormat("<li>{0} ({1})</li>", s.TenSach, s.GiaBan);
                    }
                    sb.Append("</ul>");
                }
            }
            sb.Append("</ol>");
            LiteralKetQua.Text = sb.ToString();

        }

        protected void btnViDu3_Click(object sender, EventArgs e)
        {
                        
            // GroupJoin: pt1
            var items = db.ChuDes
                         .GroupJoin(db.Saches,              /// inner
                                cd => cd.MaChuDe,        /// outerKeySelector
                                sach => sach.MaChuDe,  /// innerKeySelector
                                (cdResult, sachResult) => new { cdResult, sachInGroup = sachResult }) /// resultSelector
                         .ToList();

            var sb = new StringBuilder("<ol>");
            foreach (var item in items)
            {
                sb.AppendFormat("<li>{0}</li>", item.cdResult.TenChuDe);
                if (item.sachInGroup.Count() > 0)
                {
                    sb.Append("<ul>");
                    foreach (var s in item.sachInGroup)
                    {
                        sb.AppendFormat("<li>{0} ({1})</li>", s.TenSach, s.GiaBan);
                    }
                    sb.Append("</ul>");
                }
            }
            sb.Append("</ol>");
            LiteralKetQua.Text = sb.ToString();

        }

        protected void btnViDu4_Click(object sender, EventArgs e)
        {
            // Khi chủ đề không có sách, sachInGroup có khởi tạo nhưng không có phần tử trong tập hợp
            // sachInGroup.Count là 0
            var dsChuDe1 = db.ChuDes
                         .OrderByDescending(x => x.MaChuDe)
                         .GroupJoin(db.Saches,              /// inner
                                        cd => cd.MaChuDe,        /// outerKeySelector
                                        s => s.MaChuDe,  /// innerKeySelector
                                        (cdResult, sachResult) => new { cdResult, sachInGroup = sachResult }) /// resultSelector
                                        .ToList();
        }

        protected void btnViDu5_Click(object sender, EventArgs e)
        {
          
            // Khi chủ đề không có sách, sachInGroup vẫn có 1 phần tử trong tập hợp với giá trị pt là null
            // sachInGroup.Count là 1
            // sachInGroup.FirstOrDefault() là null
            var dsChuDe2 = db.ChuDes
                          .OrderByDescending(x => x.MaChuDe)
                          .GroupJoin(db.Saches,              /// inner
                                        cd => cd.MaChuDe,        /// outerKeySelector
                                        s => s.MaChuDe,  /// innerKeySelector
                                        (cdResult, sachResult) => new { cdResult, sachInGroup = sachResult.DefaultIfEmpty()}) /// resultSelector
                                        .ToList();
                       
        }
    }
}