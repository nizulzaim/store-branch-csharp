using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.manager
{
    public partial class transactionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "Product ID","Product Name", "Quantity", "Price (pcs)", "Total Price" };
            Table table1 = new Table();
            TableRow row;
            TableCell cell;

            var transactionId = Request.QueryString["id"];

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

            foreach (var item in Transaction.transactionItems(Int32.Parse(transactionId)))
            {
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>" + item.product().Id + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.product().Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.NumOfItem.ToString() + "pcs";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "RM " + item.lockPrice.ToString("0.00");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "RM " + (item.lockPrice * (double)item.NumOfItem).ToString("0.00");
                row.Cells.Add(cell);


                table1.Rows.Add(row);
            }

            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }
    }
}