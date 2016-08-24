using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;
namespace Baitap.Demo
{
    public partial class ExRawSQLQuery : System.Web.UI.Page
    {
       
        protected void btnSqlQuery1_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                var items= db.ChungLoais.SqlQuery("Select * From ChungLoai").ToList();
                gvKetQua.DataSource = items;
                gvKetQua.DataBind();
            }
        }

        protected void btnSqlQuery2_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                gvKetQua.DataSource = db.SanPhams.SqlQuery("Select * From SanPham Where LoaiID = @p0", 19).ToList();
                gvKetQua.DataBind();
            }
        }

        protected void btnExecuteSqlCommandInsert_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                db.Database.ExecuteSqlCommand("Insert Into ChungLoai(Ten,BiDanh) Values(@p0,@p1)", "Chủng loại mới", "Chung-loai-moi");
                lblThongBao.Text = "Ghi thành công";
            }

        }

        protected void btnExecuteSqlCommandUpdate_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                int kq = db.Database.ExecuteSqlCommand("Update SanPham Set Ten=@p0 Where SanPhamID=@p1","Sản phẩm mới", 25);
                lblThongBao.Text = kq.ToString();
            }
        }

        protected void btnExecuteSqlCommandDelete_Click(object sender, EventArgs e)
        {
            using (DienMayDbContext db = new DienMayDbContext())
            {
                try
                { 
                   int kq= db.Database.ExecuteSqlCommand("Delete From ChungLoai Where Ten like @p0", "Chủng loại mới%");
                   lblThongBao.Text = kq.ToString();
                }
                catch(Exception ex)
                {
                    lblThongBao.Text = ex.Message;
                }
            }
        }

       
    }
}