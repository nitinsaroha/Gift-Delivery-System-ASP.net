<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Gift_Delivery_Management.Registration" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <script src="Scripts/bootstrap.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.11.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Styles/normalize.css" rel="stylesheet" type="text/css" />
    <link href="Styles/styles.css" rel="stylesheet" type="text/css" />
</head>
<body class = "bg">
    
    <div class = "container margin-bottom">
        <header class="special_header">
            <div class="page-header">
                <h1>New User Registration</h1>
            </div>
            
        </header>

    <form id="form1" class="form" runat="server" defaultfocus="txtname">
        <div class  ="container">
                <div class = "row">
                    <div class = "col-md-2 col-lg-offset-10">
                        <asp:Button ID="Button4" class = "side_button btn btn-default btn-lg" 
                            runat = "server" Text="Home" onclick="Button4_Click" TabIndex="11" 
                            CausesValidation="False"></asp:Button>
                    </div>
                </div>
            </div>
        <div class = "container col-lg-offset-1">
            <div class="row">
                <div class="col-md-3">
                   <asp:TextBox ID="txtname" class="text-book" runat="server" TabIndex="1" placeholder = "Name"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqvalname" class="" runat="server"
         ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtname"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="validatename" class="validator name" runat="server"
        ErrorMessage="*Invalid Name" ControlToValidate="txtname" ForeColor="#f1c40f"
        ValidationExpression="[a-zA-Z]+\s{1}[a-zA-Z]+|[a-zA-Z]+\s{1}[a-zA-Z]+\s{1}[a-zA-Z]+"></asp:RegularExpressionValidator>
                </div>

                <div class="col-md-3 col-lg-offset-3">
                    <asp:TextBox ID="txtcontact" class="text-book" runat="server" MaxLength="10" TabIndex="2"
                    placeholder = "Phone Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalcontact" class="" runat="server"
        ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtcontact"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="valphone" class="validator contact" runat="server"
        ControlToValidate="txtcontact" ErrorMessage="*Invalid Phone No." ValidationExpression="\d{10}"
        ForeColor="#f1c40f"></asp:RegularExpressionValidator>
                </div>    
            </div>

            <div class="row">
                <div class="col-md-3">
                   <asp:TextBox ID="txtemail" class="text-book" runat="server" TabIndex="3" placeholder = "Email"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqvalemail" class="validator email" runat="server"
        ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtemail" 
                        Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="validateemail" class="validator email" runat="server"
        ControlToValidate="txtemail" ErrorMessage="*Invalid Email" ForeColor="#f1c40f"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
         <asp:CustomValidator ID="exvalemail" class="validator email" runat="server" ControlToValidate="txtemail"
        ErrorMessage="*Already Exists" ForeColor="#f1c40f" 
                        OnServerValidate="exvalemail_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                </div>

                <div class="col-md-3 col-lg-offset-3">
                   <asp:TextBox ID="txtpassword" class="text-book" runat="server" 
                        TextMode="Password" TabIndex="4"
                   placeholder = "Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqvalpassword" class="validator password" runat="server"
        ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtpassword"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valpassword" runat="server" class="validator password"
                    ControlToValidate="txtpassword" ErrorMessage="*Invalid Password" ForeColor="#f1c40f"
                    ValidationExpression="^[a-zA-Z]{1}(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&amp;])[A-Za-z\d$@$!#]{7,}$"></asp:RegularExpressionValidator>
                </div>    
            </div>

            <div class="row">
                <div class="col-md-3">
                   <asp:TextBox ID="txtretype" class="text-book" runat="server" TextMode="Password" TabIndex="5"
                   placeholder = "Confirm Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqvalretype" class="validator retype" runat="server"
        ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtretype"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="valretype" class="validator retype" runat="server" ControlToCompare="txtpassword"
        ControlToValidate="txtretype" ErrorMessage="*Not Matching" ForeColor="#f1c40f"></asp:CompareValidator>
                </div>

                <div class="col-md-3 col-lg-offset-3">
                   <asp:TextBox ID="txtaddress" class="text-book" runat="server" 
                        TextMode="MultiLine" TabIndex="6"
                   placeholder = "Enter Address"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqvaladdress" class="validator address" runat="server"
        ErrorMessage="*Input Required" ForeColor="#f1c40f" ControlToValidate="txtaddress"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="valaddress" class="validator address" runat="server"
        ControlToValidate="txtaddress" ErrorMessage="*Invalid Address" ForeColor="#f1c40f"
        ValidationExpression="[A-Za-z0-9\.\-\s\,\/\n]{15,}"></asp:RegularExpressionValidator>
                </div>    
            </div>

            <div class="row">
                <div class="col-md-3">
                   <asp:TextBox ID="txtdob" class="text-book" runat="server" TabIndex="7"
                   placeholder = "Date of Birth"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqvaldob" class="validator dob" runat="server" ErrorMessage="*Input Required"
        ForeColor="#f1c40f" ControlToValidate="txtdob"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="valdob" class="validator dob" runat="server" ErrorMessage="*Invalid Date"
        Type="Date" ControlToValidate="txtdob" ForeColor="#f1c40f"></asp:RangeValidator>
                </div>

                <div class="col-md-3 col-lg-offset-3">
                   <asp:DropDownList ID="ddlgender" class="text-book" runat="server" 
                        AutoPostBack="True" TabIndex="8">
                        <asp:ListItem>Select Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="reqvalgender" class="validator gender" runat="server" ErrorMessage="*Input Required"
        ForeColor="#f1c40f" Display="Dynamic" OnServerValidate="reqvalgender_ServerValidate"
        ControlToValidate="ddlgender" EnableClientScript="False" /> 
                </div>    
            </div>

            <div class="row">
                <div class="col-md-1 col-lg-offset-3">
                    <asp:Button ID="btnreset" runat="server" class="u_button btn btn-default btn-lg" Text="Reset" 
                    CausesValidation="False" TabIndex="10" OnClick="btnreset_Click" />
                </div>
                <div class="col-md-1 col-lg-offset-1">
                   <asp:Button ID="btnsubmit" class="u_button btn btn-default btn-lg" runat="server"
                   Text="Submit" TabIndex="9" OnClick="btnsubmit_Click" />
                </div>    
            </div>
        </div>
    </form>
    </div>
     <script type="text/javascript">
         $(document).ready(function () {
             $("#txtdob").datepicker();
         });
    </script>
    <script type="text/javascript">
        function gender(oSrc, args) {
            args.IsValid = (args.Value.Equals("Select") == false);
        }
    </script>
</body>
</html>
