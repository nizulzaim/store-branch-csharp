<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="transactionDetails.aspx.cs" Inherits="StoreBranchApp.dashboard.manager.transactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <form id="form1" runat="server" class="ui form">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div style="margin-top: 30px;">
            </div>
            <h2 class="ui dividing header">View Transaction Item</h2>

            <a href="/dashboard/manager/transactionCancel.aspx" style="margin-bottom: 10px;" class="ui right floated labeled icon button">
                Cancel Transaction
            </a>
        </form>
    </div>
</asp:Content>
