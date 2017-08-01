using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.manager
{
    public partial class transactionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "Transaction ID", "Made By", "Date Time Created", "Manage" };
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

            User user = StoreBranchApp.User.findOne(MySession.Current.LoginId);

            foreach (var item in Transaction.findByBranch(StoreBranchApp.User.findOne(MySession.Current.LoginId).BranchId))
            {
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>" + item.Id + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = StoreBranchApp.User.findOne(item.UserId).Username.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.CreatedAt.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = @"<div class='ui buttons'><a href='/dashboard/manager/transactionDetails.aspx?id=" + item.Id + "' class='green ui button'>View Transaction Item</a><a href='/dashboard/manager/transactionCancel.aspx?id=" + item.Id + "' class='green ui button'>Cancel Transaction</a></div>";
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }

            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }
    }
}