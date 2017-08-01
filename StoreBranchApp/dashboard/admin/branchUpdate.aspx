<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="branchUpdate.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.branchUpdate" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server">
            <h2 class="ui dividing header">Update Branch</h2>
            <div class="ui form">
                <div class="field">
                    <label>Branch Name</label>
                    <asp:TextBox ID="branchNameText" runat="server" placeholder="Branch Name"></asp:TextBox>
                </div>
                <div class="field">
                    <label>Short Text</label>
                    <asp:TextBox ID="branchAddressText" TextMode="multiline" runat="server" placeholder="Branch Address"></asp:TextBox>
                </div>
                <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Text="Update Branch" OnClick="SubmitButton_Click" />
            </div>
        </form>
    </div>
</asp:Content>

