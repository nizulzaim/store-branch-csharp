using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class branchUpdate : System.Web.UI.Page
    {
        int id;
        Branch b;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Int32.Parse(Request.QueryString["id"]);
            b = StoreBranchApp.Branch.findOne(id);
            if (!IsPostBack)
            {
                branchNameText.Text = b.Name;
                branchAddressText.Text = b.Address;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            b.Name = branchNameText.Text;
            b.Address = branchAddressText.Text;

            b.save();

            Response.Redirect("/dashboard/admin/branchList.aspx");
        }
    }
}