using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiTap.Models;
namespace BaiTap.Demo
{
    public partial class ExExplicitlyLoading : System.Web.UI.Page
    {

        // Explicitly Loading
        // Khi Lazy Loading Enadled là False
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                var loai1 = db.Loais.Find(1);

                // Load chungloai liên quan đến loai 
                db.Entry(loai1).Reference(p => p.ChungLoai).Load();

                // Hoặc:
                var loai2 = db.Loais.Find(2);
                db.Entry(loai2).Reference("ChungLoai").Load();

               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (var db = new DienMayDbContext())
            {
                var loai1 = db.Loais.Find(1);
                // Load related entities
                db.Entry(loai1).Collection(p => p.SanPhams).Load();

                // Load the SanPhams related to a given loai2
                // using a string to specify the relationship 
                var loai2 = db.Loais.Find(2);
                db.Entry(loai2).Collection("SanPhams").Load();

            }
            }
    }
}
