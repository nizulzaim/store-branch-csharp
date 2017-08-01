using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class productToggleShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"]);

            Product p = Product.findOne(id);
            if (p.Show == 0)
            {
                p.Show = 1;
            } else
            {
                p.Show = 0;
            }

            p.save();
            Response.Redirect("/dashboard/admin/productList.aspx");
        }
    }
}