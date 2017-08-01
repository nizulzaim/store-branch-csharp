<%@ Page Title="" Language="C#" MasterPageFile="~/Staff.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StoreBranchApp.dashboard.staff.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server" class="ui form">
        <div class="ui inverted segment" style="margin: -20px;">
            <div class="ui container">
                <div class="row ui form" style="padding-bottom: 40px; padding-top: 20px;">
                    <div class="ui  input">
                        <asp:TextBox placeholder="Insert Barcode" ID="AddTextbox" runat="server"></asp:TextBox>
                    </div>
                    <style>
                        .marginYo {
                            margin-top: 8px !important;
                        }
                    </style>
                    <asp:Button Width="" CssClass="right floated ui button marginYo" ID="AddBtn" runat="server" Text="Add Item" OnClick="Button1_Click" />
                    <asp:Button Width="" CssClass="right floated ui button marginYo red" ID="CheckOutBtn" runat="server" Text="Checkout" OnClick="CheckOutBtn_Click" />
                </div>
            </div>
        </div>
    </form>

</asp:Content>
