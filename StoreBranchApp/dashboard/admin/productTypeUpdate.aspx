<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="productTypeUpdate.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.productTypeUpdate" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="ui container">

        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server">
            <h2 class="ui dividing header">Update Branch</h2>
            <div class="ui form">
                <div class="field">
                    <label>Branch Name</label>
                    <asp:TextBox ID="productTypeNameText" runat="server" placeholder="Product Type Name"></asp:TextBox>
                </div>
                <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Text="Update Product Type" OnClick="SubmitButton_Click" />
            </div>
        </form>
    </div>
</asp:Content>
