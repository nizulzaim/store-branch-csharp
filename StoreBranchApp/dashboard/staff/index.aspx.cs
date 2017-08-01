using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.staff
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] header = { "ProductID", " Barcode", "Name", "No Of Item", "Price" };
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

            foreach (var item in MySession.Current.transactionLists)
            {
                Product p = Product.findOne(item.ProductId);
                row = new TableRow();
                row.TableSection = TableRowSection.TableBody;

                cell = new TableCell();
                cell.Text = @"<div class='ui ribbon label'>" + p.Id + "</div>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = p.Name.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = p.Barcode.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.NumOfItem.ToString();

                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "RM" + p.Price.ToString();
                row.Cells.Add(cell);

                table1.Rows.Add(row);
            }

            row = new TableRow();
            row.TableSection = TableRowSection.TableBody;

            cell = new TableCell();
            cell.Text = "";
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = "";
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = "";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = @"<b>Total</b>";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "RM" + MySession.Current.transactionLists.Sum(x => x.NumOfItem * Product.findOne(x.ProductId).Price).ToString("F");
            row.Cells.Add(cell);

            table1.Rows.Add(row);

            table1.Attributes.Add("Class", "ui basic aligned table");

            form1.Controls.Add(table1);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TransactionItem ti = new TransactionItem();
            ti.ProductId = Product.findOne(AddTextbox.Text).Id;
            User u = StoreBranchApp.User.findOne(MySession.Current.LoginId);
            bool getInStock = false;
            foreach(var s in Stock.distinctBranch(u.BranchId))
            {
                if (s.ProductId == ti.ProductId)
                {
                    var lol = MySession.Current.transactionLists.Where(x => x.ProductId == ti.ProductId);
                    if (s.availableStock() > 0 )
                    {
                        getInStock = true;
                    }

                    if (lol.Count() > 0 && s.availableStock() <= lol.First().NumOfItem)
                    {
                        getInStock = false;
                    }
                }
            }

            if (!getInStock)
            {
                Response.Redirect(Request.RawUrl);
            }

            foreach(var item in MySession.Current.transactionLists)
            {
                if (item.ProductId == ti.ProductId)
                {
                    item.NumOfItem++;
                    Response.Redirect(Request.RawUrl);
                    return;
                }
            }
            MySession.Current.transactionLists.Add(ti);
            Response.Redirect(Request.RawUrl);
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            User u = StoreBranchApp.User.findOne(MySession.Current.LoginId);
            Transaction t = new Transaction();
            t.BranchId = u.BranchId;
            t.UserId = u.Id;
            t.save();

            foreach(var x in MySession.Current.transactionLists)
            {
                x.TransactionId = t.Id;
                x.lockPrice = x.product().Price;
                x.save();
            }

            MySession.Current.transactionLists = new List<TransactionItem>();
            Response.Redirect(Request.RawUrl);
        }
    }
}