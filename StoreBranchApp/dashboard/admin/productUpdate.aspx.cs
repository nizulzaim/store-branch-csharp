using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreBranchApp.dashboard.admin
{
    public partial class productUpdate : System.Web.UI.Page
    {
        int id;
        Product p;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Int32.Parse(Request.QueryString["id"]);
            p = StoreBranchApp.Product.findOne(id);
            if (!IsPostBack)
            {
                NameText.Text = p.Name;
                ProductTypeList.SelectedValue = p.TypeId.ToString();
                BarcodeText.Text = p.Barcode;
                PriceText.Text = p.Price.ToString("F");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            p.Name = NameText.Text;
            p.TypeId = Int32.Parse(ProductTypeList.SelectedValue);
            p.Barcode = BarcodeText.Text;
            p.Price = Double.Parse(PriceText.Text);

            p.save();

            Response.Redirect("/dashboard/admin/productList.aspx");
        }
    }
}