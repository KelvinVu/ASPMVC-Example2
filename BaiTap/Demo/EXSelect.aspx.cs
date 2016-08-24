using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;

namespace BaiTap.Demo
{
    public partial class EXSelect : System.Web.UI.Page
    {
        DienMayDbContext db = new DienMayDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVd1_Click(object sender, EventArgs e)
        {
            var items = db.SanPhams
                .AsEnumerable()// trường hợp ít xài
                .Select(p => new { p.Ten, DonGia = p.GiaBan.ToString("#,##0VND") })
                .ToList();
            grv2.DataSource = items;
            grv2.DataBind();
        }

        protected void btnVd2_Click(object sender, EventArgs e)
        {
            var items = db.SanPhams
                .ToList()
                .Select(p => new { p.Ten, DonGia = p.GiaBan.ToString("#,##0VND") });//linq to object

            grv2.DataSource = items;
            grv2.DataBind();
        }
    }
}