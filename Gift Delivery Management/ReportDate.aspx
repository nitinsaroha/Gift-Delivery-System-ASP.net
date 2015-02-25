<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDate.aspx.cs" Inherits="Gift_Delivery_Management.ReportDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Delivery Report</title>
     <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <link href="Styles/jquery.datetimepicker.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.datetimepicker.js" type="text/javascript"></script>
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header class = "special_header">
        <div class="page-header">
            <h1>Admin Panel</h1>
        </div>

        
        </header>

        <form id="form1" class="form" runat="server">
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
            <div class = "container col-lg-offset-3">
                <div class = "row">
                    <div class = "col-md-3">
                        <asp:Label ID="Label1" class="lb_up" runat="server" Text="From Booking Date"></asp:Label>
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="date1" class="date-pick" runat="server" ></asp:TextBox>
                    </div>
                    <div class = "col-md-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class="" runat="server" ControlToValidate="date1" ErrorMessage="Please Enter a Date" ValidationGroup="v1" ForeColor="#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-4 col-lg-offset-3">
                        <asp:RangeValidator ID="RangeValidator1" class="" runat="server" ControlToValidate="Date1"
                            Type="Date" 
                            ErrorMessage="Date should not be greater than or equal to today's date" 
                            Display="Dynamic" ForeColor="#f1c40f"></asp:RangeValidator>
                    </div>
                </div>
            
                <div class = "row">
                    <div class = "col-md-3">
                        <asp:Label ID="Label2" class="lb_up" runat="server" Text="To Booking Date"></asp:Label>            
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="date2" class="date-pick" runat="server" ValidationGroup="v1"></asp:TextBox>
                    </div>
                    <div class = "col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class="" runat="server" ErrorMessage="Please Enter a Date" ValidationGroup="v1" ControlToValidate="date2" ForeColor="#f1c40f"></asp:RequiredFieldValidator>        
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-4 col-lg-offset-3">
                            <asp:RangeValidator ID="RangeValidator2" class="" 
                        runat="server" Type="Date" ControlToValidate="Date2"
                        ErrorMessage="Date should not be greater than today's date" 
                        Display="Dynamic" ForeColor="#f1c40f"></asp:RangeValidator>
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-4 col-lg-offset-3">
                        <asp:CompareValidator ID="CompareValidator1" class="" runat="server" 
                        ErrorMessage="To-Booking Date should be Greater than From-Booking Date " 
                        ControlToCompare="date2" ControlToValidate="date1" Operator="LessThanEqual" 
                        Type="Date" ForeColor="#f1c40f"></asp:CompareValidator>
                    </div>                                       
                </div>

                <div class = "row col-lg-offset-1">
                    <div class = "col-md-2">
                        <asp:Button ID="Reset" runat="server" class="u_button btn btn-default btn-lg" Text="Reset" onclick="Reset_Click" CausesValidation="False" ></asp:Button>
                    </div>
                    <div class = "col-md-2">
                        <asp:Button ID="Submit" class="u_button btn btn-default btn-lg" runat="server" Text="Submit" ValidationGroup="v1" onclick="Submit_Click" />        
                    </div>
                </div>
            </div>
        </form>
    </div>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#date1').datetimepicker({format:"Y-m-d",timepicker:"false"});
            });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#date2').datetimepicker({format:"Y-m-d",timepicker:"false"});
            });
    </script>
        
    </body>
</html>
