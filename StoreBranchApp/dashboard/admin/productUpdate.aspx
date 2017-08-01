<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="productUpdate.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.productUpdate" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="ui container">

        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Update Product</h2>
            <div class="field">
                <label>Product Name</label>
                <asp:TextBox ID="NameText" runat="server" placeholder="Product Name"></asp:TextBox>
            </div>
            <div class="field">
                <label>Product Type</label>
                <asp:DropDownList ID="ProductTypeList" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
            <div class="field">
                <label>Product Barcode</label>
                <asp:TextBox ID="BarcodeText" runat="server" placeholder="Product Barcode"></asp:TextBox>
            </div>
            <div class="field">
                <label>Product Price</label>
                <asp:TextBox ID="PriceText" runat="server" placeholder="Product Price (RM)"></asp:TextBox>
            </div>

            <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Text="Update Branch" OnClick="SubmitButton_Click" />
        </form>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:storeBranchDBConnectionString %>" SelectCommand="SELECT * FROM [ProductType]"></asp:SqlDataSource>

</asp:Content>
