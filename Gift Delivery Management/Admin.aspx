<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Gift_Delivery_Management.Admin" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
     <div class = "container margin-bottom">
        <header class = "special_header">
            <div class="page-header">
                <h1>Admin Panel</h1>
            </div>
        </header>

        <form id="admin" class="form" runat="server">
            <div class  ="container">
                <div class = "row">
                    <div class = "col-md-2 col-lg-offset-10">
                        <asp:Button ID="Button4" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Logout" onclick="Button4_Click" 
                            CausesValidation="False"></asp:Button>
                    </div>
                </div>
            </div>
            <div class = "container col-lg-offset-4">
                <div class="row">
                    <div class="col-md-2">
                        <asp:Button ID="gift" class="btn btn-default btn-lg" runat="server" Text="Add Gift" onclick="gift_Click" />            
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="generate" class="btn btn-default btn-lg" runat="server" Text="Generate Report" onclick="generate_Click" />            
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1 col-lg-offset-1">
                        <asp:Button ID="update" class="btn btn-default btn-lg" runat="server" Text="Update Status" onclick="update_Click" />            
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
