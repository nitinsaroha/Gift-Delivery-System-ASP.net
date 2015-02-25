<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryReport.aspx.cs" Inherits="Gift_Delivery_Management.DeliveryReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Delivery Report</title>
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
    <form id="Report" class="form" runat="server">
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
        <div class = "container col-lg-offset-2">
            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="GiftType" class="lb_up" runat="server" Text="Gift Type"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:DropDownList ID="typelist" class="lb_up rp-color" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="typelist_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class = "col-md-2 col-lg-offset-1">
                    <asp:Label ID="tamt" class="lb_up" runat="server" Text="Total Amount"></asp:Label>
                </div>
                <div class = "col-md-1">
                    <asp:Label ID="TAlabel" class="date-pick" runat="server"></asp:Label>                
                </div>
            </div>

            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="Subid" class="lb_up" runat="server" Text="Sub ID"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:DropDownList ID="idlist" class="lb_up rp-color" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="idlist_SelectedIndexChanged">
                    </asp:DropDownList>                
                </div>
                <div class = "col-md-2 col-lg-offset-1">
                    <asp:Label ID="amt" class="lb_up" runat="server" Text="Amount"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:Label ID="Amtlabel" class="date-pick" runat="server" ></asp:Label>
                </div>
            </div>
            
            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="Bookingid" class="lb_up" runat="server" Text="Booking ID "></asp:Label>                
                </div>
                <div class = "col-md-2">
                    <asp:DropDownList ID="bookingidlist" class="lb_up rp-color" runat="server" AutoPostBack="True" onselectedindexchanged="bookingidlist_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class = "col-md-2 col-lg-offset-1">
                    <asp:Label ID="quant" class="lb_up" runat="server" Text="Quantity"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:Label ID="quantlabel" class="date-pick" runat="server" ></asp:Label>    
                </div>
            </div>
 
            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="status" class="lb_up" runat="server" Text="Status"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:Label ID="Statlabel" class="date-pick" runat="server" ondatabinding="bookingidlist_SelectedIndexChanged" ></asp:Label>
                </div>
            </div>
            
            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="edate" class="lb_up" runat="server" 
                    Text="Expected Delivery Date"></asp:Label>
                </div>
                <div class = "col-md-2">
                    <asp:Label ID="edlabel" class="date-pick" runat="server" ></asp:Label>
                </div>
            </div>

            <div class = "row">
                <div class = "col-md-2">
                    <asp:Label ID="adate" class="lb_up" runat="server" Text="Actual Delivery Date"></asp:Label>                
                </div>
                <div class = "col-md-2">
                    <asp:Label ID="adlabel" class="date-pick" runat="server" ></asp:Label>                
                </div>
            </div>
        </form>
    </div>
</body>
</html>
