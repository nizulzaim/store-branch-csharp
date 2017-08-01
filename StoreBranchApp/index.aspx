<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StoreBranchApp.App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/ui/semantic.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: #DADADA;
        }

            body > .grid {
                height: 100%;
            }

        .image {
            margin-top: -100px;
        }

        .column {
            max-width: 450px;
        }
    </style>
</head>
<body>
    <div class="ui middle aligned center aligned grid">
        <div class="column">
            <h2 class="ui green image header">
                <img src="/assets/img/logo.png" class="image" />
                <div class="content">
                    Log-in to your account
                </div>
            </h2>
            <form class="ui large form" id="form1" runat="server">
                <div class="ui stacked segment">
                    <div class="field">
                        <div class="ui corner labeled input">
                            <div class="ui corner label">
                                <i class="asterisk icon"></i>
                            </div>
                            <asp:TextBox  placeholder="Username" ID="UsernameTextbox" runat="server" OnTextChanged="UsernameTextbox_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="ui corner labeled input">
                            <div class="ui corner label">
                                <i class="asterisk icon"></i>
                            </div>
                            <asp:TextBox TextMode="Password" placeholder="Password" ID="PasswordTextbox" runat="server" OnTextChanged="PasswordTextbox_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="ui fluid large green submit button" OnClick="LoginButton_Click" />
                </div>
                <div class="ui error message visible" visible="false" runat="server" id="errorBlock">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password field is required" ControlToValidate="PasswordTextbox"></asp:RequiredFieldValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ErrorMessage="Username field is required" ControlToValidate="UsernameTextbox"></asp:RequiredFieldValidator>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
