<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="branchList.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.branchList" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Manage Branch</h2>

            <button id="addButton" style="margin-bottom: 10px;" class="ui right floated labeled icon button">
                <i class="plus icon"></i>
                Add New Branch
            </button>


            <div class="ui small modal">
                <i class="close icon"></i>
                <div class="header">
                    Add New Branch
                </div>
                <div class="content">
                    <div class="ui form">
                        <div class="field">
                            <label>Branch Name</label>
                            <asp:TextBox ID="branchNameText" runat="server" placeholder="Branch Name"></asp:TextBox>
                        </div>
                        <div class="field">
                            <label>Branch Address</label>
                            <asp:TextBox ID="branchAddressText" TextMode="multiline" runat="server" placeholder="Branch Address"></asp:TextBox>
                        </div>

                        <div class="field">
                            <label>Branch Staff Username</label>
                            <asp:TextBox ID="branchUsernameText" runat="server" placeholder="Branch Staff Username"></asp:TextBox>
                        </div>

                        <div class="field">
                            <label>Branch Staff Password</label>
                            <asp:TextBox ID="branchPasswordText" runat="server" placeholder="Branch Staff Password"></asp:TextBox>
                        </div>

                        <div class="field">
                            <label>Branch Manager Username</label>
                            <asp:TextBox ID="branchManUsernameText" runat="server" placeholder="Branch Manager Username"></asp:TextBox>
                        </div>

                        <div class="field">
                            <label>Branch Manager Password</label>
                            <asp:TextBox ID="branchManPasswordText" runat="server" placeholder="Branch Manager Password"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="actions">
                    <div class="ui black deny button">
                        Cancel
                    </div>
                    <asp:Button CssClass="ui positive right button" ID="SubmitButton" runat="server" Text="Add New Branch" OnClick="SubmitButton_Click" />
                </div>
            </div>
        </form>
    </div>
</asp:Content>
