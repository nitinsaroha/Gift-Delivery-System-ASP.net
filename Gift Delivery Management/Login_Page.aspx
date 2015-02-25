<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Page.aspx.cs" Inherits="Gift_Delivery_Management.Login_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header class = "special_header">
            <div class="page-header">
                <h1>Login</h1>
            </div>

           
        </header>

        <form id="login" class="form" runat="server" defaultbutton="logon">
            <div class  ="container">
                <div class = "row">
                    <div class = "col-md-1 col-md-offset-10">
                        <asp:Button ID="Button3" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Home" CausesValidation="False"></asp:Button>
                    </div>
                </div>
            </div>
            <div class = "container col-lg-offset-4">
                <div class="row">
                    <div class="col-md-4">
                        <asp:TextBox ID="username" class="text-book" runat="server" 
                        AutoCompleteType="Disabled" placeholder = "Username"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="vuser" class="" runat="server"
                        ErrorMessage="*Input Required" ControlToValidate="username" Display="Dynamic" ></asp:RequiredFieldValidator>
                    </div>    
                </div>

                <div class="row">
                    <div class="col-md-4">
                        <asp:TextBox ID="password" class="text-book" runat="server" AutoCompleteType="Disabled" 
                        TextMode="Password" placeholder = "Password"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="vpass" class="" runat="server"
                        ErrorMessage="*Input Required" ControlToValidate="password" Display="Dynamic"
                        Font-Size="Small" ForeColor="#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-1 j_reset">
                        <asp:Button ID="j_reset" class="btn btn-default btn-lg" runat="server" Text="Reset" CausesValidation="False" OnClick="reset_Click" />
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="logon" class="btn btn-default btn-lg j_login" runat="server" Text="Login" OnClick="logon_Click"/>
                    </div>
                </div>
            
                <div class="row">
                    <div class="col-md-2 col-lg-offset-1">
                        <asp:Button ID="new" class="j_signup btn btn-default btn-lg" runat="server" Text="Sign Up" CausesValidation="False" OnClick="new_Click"/>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
