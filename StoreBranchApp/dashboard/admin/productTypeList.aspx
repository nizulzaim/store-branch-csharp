<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="productTypeList.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.productTypeList" %>

<asp:Content ContentPlaceHolderID="content" runat="server">

    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Manage Product Type</h2>

            <button id="addButton" style="margin-bottom: 10px;" class="ui right floated labeled icon button">
                <i class="plus icon"></i>
                Add New Product Type
            </button>


            <div class="ui small modal">
                <i class="close icon"></i>
                <div class="header">
                    Add New Product Type
                </div>
                <div class="content">
                    <div class="ui form">
                        <div class="field">
                            <label>Product Type Name</label>
                            <asp:TextBox ID="typeNameText" runat="server" placeholder="Product Type Name"></asp:TextBox>
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
    <!-- Site content !-->
</asp:Content>
