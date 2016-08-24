using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;
using System.Collections;

namespace BaiTap.Demo
{
    public partial class ExLinqToEntities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DienMayDbContext db = new DienMayDbContext();
        protected void btn1_Click(object sender, EventArgs e)
        {
            // đọc thông tin của 5 sản phẩm mới nhất (căn cứ thứ tự nhập liệu)
            List<SanPham> items = db.SanPhams
                .OrderByDescending(p => p.SanPhamID)
                .Take(5)
                .ToList();
            grv1.DataSource = items;
            grv1.DataBind();
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            // bỏ qua 10 sản phẩm đầu tiên, lấy thông tin 5 sp kế tiếp
            List<SanPham> items = db.SanPhams
                         .OrderBy(p=>p.SanPhamID)
                         .Skip(10)
                         .Take(5)
                         .ToList();
            grv1.DataSource = items;
            grv1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // đọc sp có id=10  co gia ban tren 3,200,000
            int giaBanTim = 3200000;
            var items = db.SanPhams
                         .Where(p => p.LoaiID == 10 && p.GiaBan >giaBanTim)
                         .OrderBy(p=>p.GiaBan)
                         .ThenBy(p=>p.Ten)
                         .Select(p=>new {p.LoaiID,TenLoai=p.Loai.Ten,p.SanPhamID,TenSanPham=p.Ten,p.GiaBan }) //anonymous type
                         .ToList();
            grv1.DataSource = items;
            grv1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // đọc thông tin của sản phẩm có sanphamid=10
            int id = 10;
            SanPham item = db.SanPhams.Find(id);
            txtSanPhamID.Text = item.SanPhamID.ToString();
            txtTenSanPham.Text = item.Ten;
            txtGiaBan.Text = item.GiaBan.ToString("#,##0VND");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            int id = 10;
            SanPham item = db.SanPhams
                .Include("Loai")
                .SingleOrDefault(p => p.SanPhamID == id);
            if (item != null)
            {
                txtSanPhamID.Text = item.SanPhamID.ToString();
                txtTenSanPham.Text = item.Ten;
                txtGiaBan.Text = item.GiaBan.ToString();
                txtTenLoai.Text = item.Loai.Ten;
            }
        }



        protected void Button6_Click(object sender, EventArgs e)
        {
            // đọc thông tin của sản phẩm có sanphamid=10
            int id = 10;
            var item = db.SanPhams
                //.Find(id) ko su dung select sau find dc
                .Select(p => new { p.SanPhamID, TenSanPham = p.Ten, p.GiaBan, TenLoai = p.Loai.Ten })
                .SingleOrDefault(p => p.SanPhamID == id);
            if (item != null)
            {
                txtSanPhamID.Text = item.SanPhamID.ToString();
                txtTenSanPham.Text = item.TenSanPham;
                txtGiaBan.Text = item.GiaBan.ToString();
                txtTenLoai.Text = item.TenLoai;
            }
        }

        protected void button7_Click(object sender, EventArgs e)
        {
            // đọc thông tin của một sản phẩm mới nhất loại "TV LCD"
            SanPham item = db.SanPhams
                .Where(p => p.Loai.Ten == "TIVI LCD")
                .OrderByDescending(p => p.SanPhamID)
                .FirstOrDefault();
            txtSanPhamID.Text = item.SanPhamID.ToString();
            txtTenSanPham.Text = item.Ten;
            txtGiaBan.Text = item.GiaBan.ToString("#,##0VND");
        }

        protected void button8_Click(object sender, EventArgs e)
        {
            // đọc thông tin của một sản phẩm mới nhất loại "TIVI LCD"
            //--> trả về 1 tập hợp list chỉ có duy nhất 1 phần tử (trường hợp này ít dùng)
            List<SanPham> item = db.SanPhams
                .Where(p => p.Loai.Ten == "TIVI LCD")
                .OrderByDescending(p => p.SanPhamID)
                .Take(1)
                .ToList();

            //xuaats thoong tin
            grv1.DataSource = item;
            grv1.DataBind();

        }

        protected void button9_Click(object sender, EventArgs e)
        {
            var items = db.Loais
                .Select(p => new { p.LoaiID, TenLoai = p.Ten, SoSanPham = p.SanPhams.Count(), maxGB = p.SanPhams.Max(s => s.GiaBan) })
                .ToList();
            grv1.DataSource = items;
            grv1.DataBind();
        }

        protected void button10_Click(object sender, EventArgs e)
        {
            var items = db.Loais
                         .Select(p => new { p.LoaiID, TenLoai = p.Ten, SoSanPham = p.SanPhams.Count(), maxGB = p.SanPhams.Max(s => s.GiaBan) })
                         .ToList();
            grv1.DataSource = items;
            grv1.DataBind();
        }
    }
}