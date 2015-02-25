<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Gift_Delivery_Management.Booking" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header class = "special_header">
        <div class="page-header">
            <h1>Customer Panel</h1>
        </div>
        </header>
        <form id="form1" class="form" runat="server">
            <div class  ="container">
                
                <div class = "row">
                
                    <div class = "col-md-2 col-lg-offset-10">
                        <asp:Button ID="Button2" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Logout" CausesValidation="False" onclick="Button2_Click"></asp:Button>
                    </div>
                </div>
            </div>            
            <div class = "container col-lg-offset-3">
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label1" runat="server" class="lb_up" Text="Gift Type"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:DropDownList ID="giftTypeList" class="lb_up rp-color" runat="server"
                        onselectedindexchanged="giftTypeList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>                
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label2" runat="server" class="lb_up" Text="Occassion"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:DropDownList ID="occassion" runat="server" class = "lb_up rp-color"
                        AutoPostBack="True" onselectedindexchanged="occassion_SelectedIndexChanged"></asp:DropDownList>                
                    </div>
                   
                </div>
                <div class = "row">
                   <div class = "col-md-2 col-lg-offset-3">
                        <asp:Button ID="Button1" runat="server" Text="Search"  class = "btn btn-default btn-lg" onclick="Button1_Click" CausesValidation="False" />                
                   </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label3" runat="server" class="lb_up" Text="Gift Sub Type"></asp:Label>                
                    </div>
                    <div class = "col-md-2">
                        <asp:DropDownList ID="giftsubtypelist" class="lb_up rp-color" runat="server" 
                        onselectedindexchanged="giftsubtypelist_SelectedIndexChanged" 
                        AutoPostBack="True"></asp:DropDownList>                
                    </div>
                </div>
        
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label4" runat="server" class="lb_up" Text="Cost"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:Label ID="Label5" class="date-pick" runat="server" Text="Rs."></asp:Label>                    
                    </div>
                </div>
                
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label6" runat="server" class="lb_up" Text="Available Quantity"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:Label ID="Label7" class="date-pick" runat="server" Text="qty"></asp:Label>                
                    </div>
                </div>
    
                 <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label8" runat="server" class="lb_up" Text="Status"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:Label ID="Label9" class="date-pick" runat="server" Text="A/O"></asp:Label>
                    </div>
                </div>
                
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label10" runat="server" class="lb_up" Text="Address"></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:TextBox ID="TextBox1" class = "date-pick" runat="server" TextMode = "MultiLine"></asp:TextBox>
                    </div>
                    <div class = "col-md-2 col-lg-offset-1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ErrorMessage="Invalid Address" ControlToValidate="TextBox1" 
                        ValidationExpression="[A-Za-z0-9\.\-\s\,\/\n]{15,}" ForeColor="#f1c40f"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2 col-lg-offset-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="Please enter the address" ControlToValidate="TextBox1" ForeColor="#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label11" runat="server" class="lb_up" Text="Phone No."></asp:Label>
                    </div>
                    <div class = "col-md-2">
                        <asp:TextBox ID="TextBox2" class = "date-pick" runat="server"></asp:TextBox>                    
                    </div>
                    <div class = "col-md-2 col-lg-offset-1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="Please enter phone number" ControlToValidate="TextBox2" ForeColor="#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class = "row">
                    <div class = "col-md-2 col-lg-offset-2">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ErrorMessage="Phone number invalid" ControlToValidate="TextBox2" 
                        ValidationExpression="[0-9]{10}" ForeColor="#f1c40f"></asp:RegularExpressionValidator>                    
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Label12" runat="server" class="lb_up" Text="Expected Delivery Date"></asp:Label>                
                    </div>
                    <div class = "col-md-2">
                        <asp:TextBox ID="TextBox3" class="date-pick" runat="server"></asp:TextBox>                
                    </div>
                    <div class = "col-md-2 col-lg-offset-1">
                        <asp:RangeValidator ID="RangeValidator1" class="validator" runat="server" 
                        ErrorMessage="Expected Delivery date should not be less then todays date" ControlToValidate="TextBox3" Type="Date" ForeColor="#f1c40f"></asp:RangeValidator>
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-2 col-lg-offset-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Please enter Delivery Date" ControlToValidate="TextBox3" ForeColor="#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2 col-lg-offset-1">
                        <asp:Button ID="btnReset" runat="server" class = "u_button btn btn-default btn-lg" Text="Reset" onclick="btnReset_Click" CausesValidation="False" />                
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="Button4" runat="server"  class = "u_button btn btn-default btn-lg" Text="Gift" onclick="Button4_Click1" />                    
                    </div>
                </div>
            </div>
        </form>
   </div>
   <script type="text/javascript">
       $(document).ready(function () {
           $("#TextBox3").datepicker({ format: "Y-m-d" });
       });
    </script>
</body>
</html>
