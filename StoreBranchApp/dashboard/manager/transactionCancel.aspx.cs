using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.manager
{
    public partial class transactionCancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            Transaction a = Transaction.findOne(Int32.Parse(id));
            a.cancel = 1;
            a.save();
            Response.Redirect("/dashboard/manager/transactionList.aspx");
        }
    }
}