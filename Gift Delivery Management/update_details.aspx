<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_details.aspx.cs" Inherits="Gift_Delivery_Management.update_details" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Update Delivery Status</title>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header class = "special_header">
            <div class="page-header">
                <h1>Admin Panel</h1>
            </div>

            
        </header>
        <form id="form" runat="server">
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
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="Label1" runat="server" class = "lb_up" Text="Booking ID : "></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label7" runat="server" class = "lb_up col-color" Text=""></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label3" runat="server" class = "lb_up" Text="Enter the status : "></asp:Label>
                      
                    
                      
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="DropDownList1" runat="server" class = "st_ddl">
                        <asp:ListItem>Pending</asp:ListItem> 
                        <asp:ListItem>Delivered</asp:ListItem>
                        <asp:ListItem>In Transit</asp:ListItem>
                    </asp:DropDownList>  
                </div>
            </div>
        <div class = "row">
            <div class="col-md-2">
                <asp:Label ID="Label4" runat="server" class = "lb_up" Text="Phone Num : "></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label6" runat="server" class = "lb_up rp-color" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" class = "lb_up" Text="Address : "></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label5" runat="server" class = "lb_up rp-color"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label8" runat="server" class = "lb_up" Text="Delivery Date : "></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="TextBox1" runat="server" class = "date-pick"></asp:TextBox>    
            </div>
        </div>
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label9" runat="server" class = "lb_up" Text="Expected Delivery Date : "></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label10" runat="server" class = "lb_up rp-color" Text=""></asp:Label>
            </div>
            <div class="col-md-4 col-lg-offset-2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="Input Required" ForeColor = "#f1c40f" ></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4 col-lg-offset-2">
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ErrorMessage="Invalid date" ControlToValidate="TextBox1" Type="Date" ForeColor = "#f1c40f"></asp:RangeValidator>
            </div>
        </div>
         
            <div class="row">
                <div class="col-md-2 col-md-offset-3">
                    <asp:Button ID="button1" class = "btn btn-default btn-lg" runat="server" 
                        Text="Reset" CausesValidation="False" onclick="button1_Click"/>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="button2" class = "btn btn-default btn-lg" runat="server" 
                        Text="Update Details" onclick="button2_Click"/>
                </div>
            </div>
        </form>


    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.date-pick').datepicker();
        });
    </script>
</body>
</html>
