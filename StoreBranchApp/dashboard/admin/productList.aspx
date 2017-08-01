<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="productList.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.productList" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Manage Product</h2>

            <button id="addButton" style="margin-bottom: 10px;" class="ui right floated labeled icon button">
                <i class="plus icon"></i>
                Add New Product
            </button>

            <div class="ui small modal">
                <i class="close icon"></i>
                <div class="header">
                    Add New Product
                </div>
                <div class="content">
                    <div class="ui form">
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
                    </div>
                </div>
                <div class="actions">
                    <div class="ui black deny button">
                        Cancel
                    </div>
                    <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Text="Add" OnClick="SubmitButton_Click" />
                </div>
            </div>
        </form>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:storeBranchDBConnectionString %>" SelectCommand="SELECT * FROM [ProductType]"></asp:SqlDataSource>

</asp:Content>

