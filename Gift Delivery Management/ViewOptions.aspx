<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOptions.aspx.cs" Inherits="Gift_Delivery_Management.ViewOptions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate Report</title>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header>
        <div class="page-header">
            <h1>Admin Panel</h1>
        </div>

        </header>

        <form id="form2" class="form" runat="server">
            <div class  ="container">
                <div class = "row">
                    <div class = "col-md-1 col-md-offset-9">
                        <asp:Button ID="home" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Home" CausesValidation="False" onclick="home_Click"></asp:Button>
                    </div>
                    <div class = "col-md-2">
                        <asp:Button ID="logout" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Logout" CausesValidation="False" onclick="logout_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class = "container col-lg-offset-2">
                <div class = "row col-lg-offset-1">
                    <div class = "col-md-2">
                        <asp:Button ID="Generatereport" class="u_button btn btn-default btn-lg" runat="server" 
                        Text="Generate Report" onclick="Generatereport_Click" />
                    </div>
                    <div class = "col-md-2 col-lg-offset-1">
                        <asp:Button ID="PdfButton" class="u_button btn btn-default btn-lg" runat="server" 
                        Text="Generate Report as PDF" onclick="PdfButton_Click" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
