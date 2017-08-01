using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class productTypeUpdate : System.Web.UI.Page
    {
        int id;
        ProductType pt;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Int32.Parse(Request.QueryString["id"]);
            pt = StoreBranchApp.ProductType.findOne(id);
            if (!IsPostBack)
            {
                productTypeNameText.Text = pt.Name;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            pt.Name = productTypeNameText.Text;
            pt.save();

            Response.Redirect("/dashboard/admin/productTypeList.aspx");
        }
    }
}