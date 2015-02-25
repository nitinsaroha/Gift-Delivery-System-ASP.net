<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add Gift.aspx.cs" Inherits="Gift_Delivery_Management.Add_Gift" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
</head>
<body class = "bg">
    <div class = "container margin-bottom">
        <header class = "special_header">
        <div class="page-header">
            <h1>Admin Panel</h1>
        </div>

        
     </header>
        <form id="form1" runat="server" class="style1">
            <div class  ="container">
                <div class = "row">
                <div class = "col-md-1 col-md-offset-9">
                        <asp:Button ID="Button3" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Home" onclick="Button3_Click" 
                            CausesValidation="False"></asp:Button>
                    </div>
                    <div class = "col-md-2">
                        <asp:Button ID="Button4" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Logout" onclick="Button4_Click" 
                            CausesValidation="False"></asp:Button>
                    </div>
                </div>
            </div>
            <div class = "container">
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="AddGift" runat="server" class = "lb_up" Text="ADD GIFT"></asp:Label>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Gift_Type" runat="server" class ="lb_up" Text="GIFT TYPE"></asp:Label>
                    </div>
                    <div class = "col-md-3">
                        <asp:DropDownList ID="GiftType_DropDownList1" runat="server" AutoPostBack="True" class = "date-pick"
                        DataTextField="type1" DataValueField="type1" onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="GiftType_TextBox" runat="server" class = "date-pick" Visible="False"></asp:TextBox>
                    </div>
                    <div class = "col-md-2">
                        <asp:RequiredFieldValidator ID="Gift_Validator" runat="server" 
                        ControlToValidate="GiftType_TextBox" ErrorMessage="Enter Gift Type" 
                            ForeColor= "#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-2">
                        <asp:RegularExpressionValidator ID="Giftrx_Validator" runat="server" 
                        ControlToValidate="GiftType_TextBox" ErrorMessage="Alphabets only" 
                            ValidationExpression="[a-zA-Z ]*" ForeColor= "#f1c40f"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Occasion_Type" runat="server" class = "lb_up" Text="OCCASION TYPE"></asp:Label>
                    </div>
                    <div class = "col-md-3">
                        <asp:DropDownList ID="OccasionType_DropDownList2" runat="server" class = "date-pick" AutoPostBack="True" 
                            DataTextField="name" DataValueField="name" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="Occasion_TextBox" runat="server"  Visible="False" class = "date-pick" ></asp:TextBox>
                    </div>
                    <div class = "col-md-2">
                        <asp:RequiredFieldValidator ID="Occasion_Validator" runat="server" 
                            ControlToValidate="Occasion_TextBox" ErrorMessage="*Enter Occasion Type" 
                            ForeColor= "#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                    <div class = "col-md-2">
                              <asp:Label ID="Gift_Label" runat="server" Text="Label" Visible="False" 
                            ForeColor="Red" Enabled="False"></asp:Label>
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-2">
                    
                        <asp:RegularExpressionValidator ID="Occasionrx_Validator" runat="server" 
                            ControlToValidate="Occasion_TextBox" ErrorMessage="*Alphabets only" 
                            ForeColor= "#f1c40f" ValidationExpression="[a-zA-Z ]*"></asp:RegularExpressionValidator>
                    </div>
                    <div class = "col-md-2">
                        <asp:Label ID="Occasion_Label" runat="server" Text="Label" Visible="False" 
                            ForeColor= "#f1c40f" Enabled="False"></asp:Label>
                    </div>
                </div>


                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Cost" runat="server" Enabled="False" class = "lb_up" Text="COST"></asp:Label> 
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="Cost_TextBox" runat="server" Enabled="False" class = "date-pick"></asp:TextBox>
                    </div>
                    <div class = "col-md-2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="Cost_TextBox" Display="Dynamic" ErrorMessage="*Enter Cost" 
                            ForeColor= "#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                    <div class = "col-md-2">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="Cost_TextBox" ErrorMessage="Invalid Input" ForeColor= "#f1c40f" 
                        
                            ValidationExpression="[1-9][0-9]*[.]+[0-9]*"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-md-2">
                        <asp:Label ID="Quantity" runat="server" Enabled="False" class = "lb_up" Text="QUANTITY"></asp:Label>
                    </div>
                    <div class = "col-md-3">
                        <asp:TextBox ID="Quantity_TextBox" runat="server" Enabled="False" class = "date-pick"></asp:TextBox>
                    </div>
                    <div class = "col-md-2">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="Quantity_TextBox" Display="Dynamic" ErrorMessage="*Enter Quantity" 
                            ForeColor= "#f1c40f"></asp:RequiredFieldValidator>
                    </div>
                    <div class = "col-md-2">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                            ControlToValidate="Quantity_TextBox" ErrorMessage="*Invalid Input" ForeColor= "#f1c40f" 
                            ValidationExpression="[1-9]{1}[0-9]+|[1-9]"></asp:RegularExpressionValidator>
                    </div>
                    <div class = "col-md-2">
                    
                    </div>
                </div>
                <div class = "row">
                    <div class = "col-md-2">
                      <asp:Button ID="Add_Button" runat="server" 
                            class = "u_button btn btn-default btn-lg" Enabled="False" 
                            onclick="Button1_Click" Text="ADD GIFT" />
                    </div>
                    <div class = "col-md-2">
                      <asp:Button ID="Reset_Button" runat="server" 
                            class = "u_button btn btn-default btn-lg" CausesValidation="False" 
                            Enabled="False" onclick="Button2_Click" Text="RESET" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
