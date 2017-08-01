using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class branchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "ID", "Name", "Address", "Date Created", "Last Updated", "Manage" };
            Table table1 = new Table();
            TableRow row;
            TableCell cell;

            row = new TableRow();
            row.TableSection = TableRowSection.TableHeader;

            foreach (string h in header)
            {
                TableHeaderCell tHead = new TableHeaderCell();
                tHead.Text = h;
                row.Cells.Add(tHead);
            }
            table1.Rows.Add(row);

            foreach(var item in Branch.findAll())
            {
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>"+ item.Id.ToString() + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Name.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Address.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.CreatedAt.ToString("hh:mm tt, dd MMMM yyyy");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.UpdatedAt.ToString("hh:mm tt, dd MMMM yyyy");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = @"<div class='ui buttons'><a href='/dashboard/admin/branchUpdate.aspx?id=" + item.Id + "' class='green ui button'>Update</a><div class='or'></div><a href='/dashboard/admin/branchDelete.aspx?id=" + item.Id + "' class='red ui button'>Delete</a></div>";
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }

            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            
            Branch branch = new StoreBranchApp.Branch();
            

            if (StoreBranchApp.User.findOne(branchUsernameText.Text) != null)
            {
                return;
            }

            if (StoreBranchApp.User.findOne(branchManUsernameText.Text) != null)
            {
                return;
            }

            branch.Name = branchNameText.Text;
            branch.Address = branchAddressText.Text;
            branch.save();

            User newUser = new StoreBranchApp.User();
            newUser.Username = branchUsernameText.Text;
            newUser.Password = branchPasswordText.Text;
            newUser.BranchId = branch.Id;
            newUser.save();


            User branchMan = new StoreBranchApp.User();
            branchMan.UserTypeId = 2;
            branchMan.Username = branchManUsernameText.Text;
            branchMan.Password = branchManPasswordText.Text;
            branchMan.BranchId = branch.Id;
            branchMan.save();

            Response.Redirect(Request.RawUrl);
        }
    }
}