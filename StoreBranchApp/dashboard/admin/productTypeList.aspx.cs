using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class productTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "ID", "Name", "Date Created", "Last Updated", "Manage" };
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

            foreach (var item in ProductType.findAll())
            {
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>" + item.Id.ToString() + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Name.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.CreatedAt.ToString("hh:mm tt, dd MMMM yyyy");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.UpdatedAt.ToString("hh:mm tt, dd MMMM yyyy");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = @"<a href='/dashboard/admin/productTypeUpdate.aspx?id=" + item.Id + "' class='green ui button'>Update</a>";
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }
            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ProductType pt = new ProductType();
            pt.Name = typeNameText.Text;
            pt.save();

            Response.Redirect(Request.RawUrl);
        }
    }
}