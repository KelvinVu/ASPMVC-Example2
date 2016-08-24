using BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTap.Demo
{
    public partial class ExJoin_Books : System.Web.UI.Page
    {
        BooksDbContext db = new BooksDbContext();


        protected void btnViDu1_Click(object sender, EventArgs e)
        {// Join 2
            var items = db.ChuDes                       /// source Collection
                        .Join(db.Saches,               /// inner Collection
                                cd => cd.MaChuDe,       /// outerKey
                                s => s.MaChuDe,      /// innerKey
                                (chuDeResult, sachResult) => new {/// result Collection
                                    chuDeResult.MaChuDe,
                                    chuDeResult.TenChuDe,
                                    sachResult.SachID,
                                    sachResult.TenSach,
                                    DonGia = sachResult.GiaBan
                                })
                                .ToList();
            gridViewKetQua.DataSource = items;
            gridViewKetQua.DataBind();

            
        }

        protected void btnViDu2_Click(object sender, EventArgs e)
        {// Join 2

            var items = db.ChuDes                       /// source Collection
                          .Join(db.Saches,               /// inner Collection
                                c => c.MaChuDe,       /// outerKey
                                s => s.MaChuDe,      /// innerKey
                                (chuDeResult, sachResult) => new { chuDeResult, sachResult })   /// result Collection
                                .ToList();
            repeaterKetQua.DataSource = items;
            repeaterKetQua.DataBind();
        }

        protected void btnViDu3_Click(object sender, EventArgs e)
        {// Join 2
            var items = db.NhaXuatBans.Join(            /// source Collection
                        db.Saches,                    /// inner Collection
                        nxb => nxb.NhaXuatBanID,        /// outerKey
                        s => s.NhaXuatBanID,         /// innerKey
                        (nxbResult, sachResult) => new{                /// result Collection
                        
                            sachResult.SachID,
                            sachResult.TenSach,
                            sachResult.GiaBan,
                            nxbResult.TenNhaXuatBan}
                        )
                       .Take(5)
                       .ToList();
            gridViewKetQua.DataSource = items;
            gridViewKetQua.DataBind();
        }

        protected void btnViDu4_Click(object sender, EventArgs e)
        {// Join 3

            var items = db.Saches                                /// Source Collection
                          .Join(db.NhaXuatBans,                 /// Inner Collection
                                s => s.NhaXuatBanID,           /// outerKey
                                nxb => nxb.NhaXuatBanID,      /// innerKey
                                (sachResult, nxbResult) => new { sachResult, nxbResult })     /// Result Collection (t: Source Collection)
                                .Join(db.ChuDes,                    /// Inner Collection
                                   t => t.sachResult.MaChuDe,       /// outerKey
                                   cd => cd.MaChuDe,                /// innerKey
                                   (tamResult, chuDeResult) => new {
                                       TenNXB = tamResult.nxbResult.TenNhaXuatBan,
                                       TenCD = chuDeResult.TenChuDe,
                                       TenSach = tamResult.sachResult.TenSach }
                                   )
                                 .Take(5)
                                 .ToList();
            gridViewKetQua.DataSource = items;
            gridViewKetQua.DataBind();
        }

       
    }
}