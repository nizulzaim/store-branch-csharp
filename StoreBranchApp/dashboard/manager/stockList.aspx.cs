using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.manager
{
    public partial class stockList : System.Web.UI.Page
    {
        Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "Product ID", "Product Name", "Barcode", "Stock Available", "Manage" };
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

            foreach (var item in Stock.distinctBranch(user.BranchId))
            {
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>" + item.ProductId + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.product().Name.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.product().Barcode.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.availableStock().ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = @"<div class='ui buttons'><a href='/dashboard/admin/branchUpdate.aspx?id=" + item.Id + "' class='green ui button'>Update</a></div>";
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }

            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }

        protected void CheckButton_Click(object sender, EventArgs e)
        {
             p = Product.findOne(ProductBarcodeText.Text);

            if (p == null)
            {
                ProductNameText.Text = "Product not found";
                ProductPriceText.Text = "Product not found";
                SubmitButton.Enabled = false;
            } else
            {
                ProductNameText.Text = p.Name;
                ProductPriceText.Text = p.Price.ToString();
                SubmitButton.Enabled = true;
            }
        }

        protected void ProductBarcodeText_TextChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = false;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            p = Product.findOne(ProductBarcodeText.Text);
            int loginId = MySession.Current.LoginId;
            User u = StoreBranchApp.User.findOne(loginId);
            int branchId = u.branch().Id;

            Stock s = new Stock();
            s.ProductId = p.Id;
            s.Balance = Int32.Parse(StockText.Text);
            s.BranchId = branchId;
            s.save();

            Response.Redirect(Request.RawUrl);
        }
    }
}