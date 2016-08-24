using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;

namespace BaiTap.Demo
{
    public partial class EXUseStoreProcedure : System.Web.UI.Page
    {
        DienMayDbContext db =new DienMayDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            // đọc các sản phẩm có loaiID=3
            //var items=db.sp_SamPhamTheoLoai(3).ToList();
            List<usp_DocSanPhamTheoLoai_Result> items = db.usp_DocSanPhamTheoLoai(3).ToList();

            grv1.DataSource = items;
            grv1.DataBind();
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            int idCL = 8;
            db.usp_XoaChungLoai(idCL);// nên bắt try catch
        }


    }
}