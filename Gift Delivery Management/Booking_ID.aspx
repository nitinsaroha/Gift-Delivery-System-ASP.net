<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking_ID.aspx.cs" Inherits="Gift_Delivery_Management.Booking_ID" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Update Delivery Status</title>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <div class="page-header">
            <h1>Admin Panel</h1>
        </div>
        <form id="form" runat="server">
            <div class  ="container">
                <div class = "row">
                    <div class = "col-md-1 col-md-offset-9">
                        <asp:Button ID="Button3" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Home" CausesValidation="False" onclick="Button3_Click"></asp:Button>
                    </div>
                    <div class = "col-md-2">
                        <asp:Button ID="Button4" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Logout" CausesValidation="False" onclick="Button4_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class = "middle container">
                <h1>Update Details</h1>
                <asp:TextBox ID ="book" class = "text-book" runat="server" placeholder = "Enter Booking ID" maxlength = "20"></asp:TextBox>
                <div class = "button-details">
                    <asp:Button ID="reset" class = "btn btn-default btn-lg" runat="server" 
                        Text="Reset" onclick="reset_Click" CausesValidation="False"/>
                    <asp:Button ID="get_details" class = "btn btn-default btn-lg" runat="server" 
                        Text="Get Details" CausesValidation="False" onclick="get_details_Click"/>
                </div>
            </div>
        </form>
    </div>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</body>
</html>
