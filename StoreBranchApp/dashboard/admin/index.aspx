<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StoreBranchApp.dashboard.admin.index" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="ui container">
        <div style="margin-top: 30px;"></div>
        <form id="form1" runat="server" class="ui form">
            <h2 class="ui dividing header">Company Report</h2>
            <div class="ui four column grid">
                <div class="column">
                    <div class="ui circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui header">Today Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.Sales("today").ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Weekly Sales
                    <div class="sub header">RM <%= StoreBranchApp.Branch.Sales("week").ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Monthly Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.Sales("month").ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
                <div class="column">
                    <div class="ui inverted circular segment" style="width: 175px; height: 175px; margin-right: 4px; margin-left: 4px;">
                        <h2 class="ui inverted header">Total Sales
                            <div class="sub header">RM <%= StoreBranchApp.Branch.Sales().ToString("0.00") %></div>
                        </h2>
                    </div>
                </div>
            </div>


            <h2 class="ui dividing header">Branch Report</h2>

            <div class="ui cards">
                <% foreach (StoreBranchApp.Branch b in StoreBranchApp.Branch.findAll().Where(x => x.Id != 1))
                    { %>
                <div class="card">
                    <div class="content">
                        <div class="header"><%= b.Name %></div>
                        <div class="description">
                            <%= b.Address %>
                        </div>
                    </div>
                    <div class="extra content">
                        <strong>Today Sales: RM <%= b.todaySales().ToString("0.00") %></strong>
                    </div>
                    <div class="extra content">
                        <strong>This Week Sales: RM <%= b.thisWeekSales().ToString("0.00") %></strong>
                    </div>
                    <div class="extra content">
                        <strong>This Month Sales: RM <%= b.thisMonthSales().ToString("0.00") %></strong>
                    </div>
                    <div class="extra content">
                        <strong>Total Sales: RM <%= b.totalSales().ToString("0.00") %></strong>
                    </div>
                </div>
                <% } %>
            </div>
        </form>
    </div>

</asp:Content>
