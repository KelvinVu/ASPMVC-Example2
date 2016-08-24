using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//--Bổ sung
using BaiTap.Models;

namespace BaiTap.Demo
{
    public partial class ExLazyLoading : System.Web.UI.Page
    {
        
       private DienMayDbContext db = new DienMayDbContext();
        protected void btnViDu1_Click(object sender, EventArgs e)
        {
           

            // Đọc tất cả thông tin từ table SanPham
            List<SanPham> items = db.SanPhams.ToList();
            
            // Xuất thông tin lên GridView
            gvwKetQua.DataSource = items;
            gvwKetQua.DataBind();

        }

        protected void btnViDu2_Click(object sender, EventArgs e)
        {
         
            // Đọc tất cả thông tin của các sản phẩm có giá bán trên 5 triệu
            List<SanPham> items = db.SanPhams
                                    .Where(p=>p.GiaBan>5000000)
                                    .ToList();

            // Xuất thông tin lên GridView
            gvwKetQua.DataSource = items;
            gvwKetQua.DataBind();
        }

        protected void btnViDu3_Click(object sender, EventArgs e)
        {


            // Đọc thông tin của 1 sản phẩm

            SanPham item = db.SanPhams.Find(8);
            //SanPham item = db.SanPhams.SingleOrDefault(p => p.SanPhamID == 4);

            // Sử dụng chiến lược tải dữ liệu Lazy Loading. ( Khi thuộc tính Lazy Loading Enadled là true)
            string tensp = item.Ten;
            string tenloai = item.Loai.Ten;
            string tenchungloai = item.Loai.ChungLoai.Ten;
            string nsx = item.NhaSanXuat.Ten;



        }

        protected void btnViDu4_Click(object sender, EventArgs e)
        {
            
        }
    }
}