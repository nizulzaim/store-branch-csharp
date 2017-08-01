<%@ Page Title="" Language="C#" MasterPageFile="~/Manager.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StoreBranchApp.dashboard.manager.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Branch Report</h2>
            <div class="ui four column grid">
                <div class="column">
                    <div class="ui circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui header">Today Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.findOne(StoreBranchApp.User.findOne(StoreBranchApp.MySession.Current.LoginId).BranchId).todaySales().ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Weekly Sales
                    <div class="sub header">RM <%= StoreBranchApp.Branch.findOne(StoreBranchApp.User.findOne(StoreBranchApp.MySession.Current.LoginId).BranchId).thisWeekSales().ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Monthly Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.findOne(StoreBranchApp.User.findOne(StoreBranchApp.MySession.Current.LoginId).BranchId).thisMonthSales().ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Total Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.findOne(StoreBranchApp.User.findOne(StoreBranchApp.MySession.Current.LoginId).BranchId).totalSales().ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
            </div>


            <h2 class="ui dividing header">Stock Report</h2>

            <div class="ui cards">
                <% foreach (StoreBranchApp.Stock b in StoreBranchApp.Stock.distinctBranch(StoreBranchApp.User.findOne(StoreBranchApp.MySession.Current.LoginId).BranchId))
                    { %>
                <div class="card">
                    <div class="content">
                        <div class="header"><%= b.product().Name %></div>
                        <div class="meta">ID : <%= b.product().Id %></div>
                    </div>
                    <div class="extra content">
                        <strong>Stock Left: <%= b.availableStock() %> pcs</strong>
                    </div>
                    <div class="extra content">
                        <strong>Current Price: RM <%= b.product().Price.ToString("0.00") %></strong>
                    </div>
                </div>
                <% } %>
            </div>
        </form>
    </div>
</asp:Content>
