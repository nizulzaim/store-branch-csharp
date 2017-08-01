using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class branchDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Int32.Parse(Request.QueryString["id"]);

            Branch b = Branch.findOne(id);
            
            
            foreach(var item in StoreBranchApp.User.findAll().Where(u => u.BranchId == b.Id))
            {
                item.delete();
            }
            b.delete();
            System.Diagnostics.Debug.WriteLine(b.DeletedAt);
            Response.Redirect("/dashboard/admin/branchList.aspx");
        }
    }
}