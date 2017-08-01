using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class productList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "ID", "Name", "Type", "Barcode","Price", "Last Updated", "Manage" };
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

            foreach (var item in Product.findAll())
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
                cell.Text = item.type().Name.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Barcode.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "RM" + item.Price.ToString("F");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.UpdatedAt.ToString("hh:mm tt, dd MMMM yyyy");
                row.Cells.Add(cell);

                cell = new TableCell();
                string iconButton = "<a href='/dashboard/admin/productToggleShow.aspx?id=" + item.Id+ "' class='circular ui blue icon button'><i class='icon hide'></i></a>";

                if (item.Show == 0)
                {
                    iconButton = "<a href='/dashboard/admin/productToggleShow.aspx?id=" + item.Id + "' class='circular ui red icon button'><i class='icon unhide'></i></a>";
                }
                cell.Text = @"<a href='/dashboard/admin/productUpdate.aspx?id=" + item.Id + "' class='green ui button'>Update</a> " + iconButton;
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }
            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Name = NameText.Text;
            p.TypeId = Int32.Parse(ProductTypeList.SelectedValue);
            p.Barcode = BarcodeText.Text;
            p.Price = Double.Parse(PriceText.Text);

            p.save();

            Response.Redirect(Request.RawUrl);
        }
    }
}