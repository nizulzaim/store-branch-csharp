using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp
{
    public partial class App : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //User newUser = new User();
            //newUser.Password = "h";
            //newUser.Username = "Sengal2";

            //bool result=  newUser.save();
            //User user = StoreBranchApp.User.findOne(11);

            //System.Diagnostics.Debug.WriteLine(user.type().Name);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            User user = StoreBranchApp.User.findOne(UsernameTextbox.Text);

            if (user == null)
            {
                errorBlock.Visible = true;
                return;
            }

            if (user.Password != PasswordTextbox.Text)
            {
                return;
            }

            MySession.Current.LoginId = user.Id;
            if (user.type().Id == 3)
            {
                Response.Redirect("/dashboard/admin/index.aspx");
            }

            if (user.type().Id == 2)
            {
                Response.Redirect("/dashboard/manager/index.aspx");
            }

            Response.Redirect("/dashboard/staff/index.aspx");
        }

        protected void UsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            errorBlock.Visible = false; 
        }

        protected void PasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            errorBlock.Visible = false;
        }
    }
}