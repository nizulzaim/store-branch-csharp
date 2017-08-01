<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="stockList.aspx.cs" Inherits="StoreBranchApp.dashboard.manager.stockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <form id="form1" runat="server" class="ui form">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="margin-top: 30px;">
            </div>
            <h2 class="ui dividing header">Manage Stock</h2>

            <button id="addButton" style="margin-bottom: 10px;" class="ui right floated labeled icon button">
                <i class="plus icon"></i>
                Add New Product
            </button>


            <div class="ui small modal">
                <asp:UpdatePanel ID="CheckUpdatePanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <i class="close icon"></i>
                        <div class="header">
                            Add New Product
                        </div>
                        <div class="content">
                            <div class="ui form">
                                <div class="field">
                                    <label>Product Barcode</label>
                                    <asp:TextBox ID="ProductBarcodeText" runat="server" placeholder="Product Barcode" OnTextChanged="ProductBarcodeText_TextChanged"></asp:TextBox>
                                </div>
                                <div class="field">
                                    <label>Product Name</label>
                                    <asp:TextBox Enabled="false" ID="ProductNameText" runat="server" placeholder="Product Name"></asp:TextBox>
                                </div>
                                <div class="field">
                                    <label>Product Price</label>
                                    <asp:TextBox Enabled="false" ID="ProductPriceText" runat="server" placeholder="Product Price (RM)"></asp:TextBox>
                                </div>
                                <div class="field">
                                    <label>Stock to Add</label>
                                    <asp:TextBox Enabled="true" ID="StockText" runat="server" placeholder="Stock To Add"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="actions">
                            <div class="ui black deny button">
                                Cancel
                            </div>
                            <asp:Button CssClass="ui right button" ID="CheckButton" runat="server" Text="Check" OnClick="CheckButton_Click" />
                            <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Enabled="false" Text="Add" OnClick="SubmitButton_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="CheckButton" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ProductBarcodeText" EventName="TextChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</asp:Content>
