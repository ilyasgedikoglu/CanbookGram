<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/vendor/bootstrap/css/bootstrap.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/fonts/iconic/css/material-design-iconic-font.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/vendor/animate/animate.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/vendor/css-hamburgers/hamburgers.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/vendor/animsition/css/animsition.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/vendor/select2/select2.min.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/css/util.css" />
    <link rel="stylesheet" type="text/css" href="~/Template/LoginRegister/css/main.css" />
    <!--===============================================================================================-->
</head>
<body>
   <div class="limiter">
        <div class="container-login100" style="background-image: url('Template/LoginRegister/images/bg-01.jpg');">
            <div class="wrap-login100 p-l-55 p-r-55 p-t-65 p-b-54">
                <form class="login100-form validate-form" id="form1" runat="server">
                    <span class="login100-form-title p-b-49">
                        <span style="color:mediumvioletred">CanBookGram</span> <span style="color:cornflowerblue">Register</span>
                    </span>
                      <div class="wrap-input100 validate-input m-b-23" data-validate="Name is required">
                        <asp:TextBox CssClass="input100" ID="txtName" placeholder="Name" runat="server"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf206;"></span>                 
                    </div>
                      <div class="wrap-input100 validate-input m-b-23" data-validate="SurName is required">
                        <asp:TextBox CssClass="input100" ID="txtSurName" placeholder="Surname" runat="server"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf206;"></span>                 
                    </div>
                      <div class="wrap-input100 validate-input m-b-23" data-validate="UserName is required">
                        <asp:TextBox CssClass="input100" ID="txtUsername" placeholder="User Name" runat="server"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf206;"></span>                 
                    </div>
                    <div class="wrap-input100 validate-input m-b-23" data-validate="Email is required">
                        <asp:TextBox CssClass="input100" ID="txtEmail" placeholder="Email" TextMode="Email" runat="server"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf206;"></span>                 
                    </div>
                    <div class="wrap-input100 validate-input" data-validate="Password is required">
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="input100"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf190;"></span>
                    </div>
                    <br />
                    <div class="container-login100-form-btn">
                        <div class="wrap-login100-form-btn">
                            <div class="login100-form-bgbtn"></div>
                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="login100-form-btn" ValidationGroup="Register" OnClick="btnRegister_Click" />
                        </div>
                    </div>
                    <br />
                     <center><asp:HyperLink ID="hypRegister" NavigateUrl="~/Login.aspx" runat="server" ForeColor="#cc00cc">Login Now!</asp:HyperLink></center>
                    <br />
                     <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                    <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter email" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
                </form>
            </div>
        </div>
    </div>


    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/bootstrap/js/popper.js"></script>
    <script src="~/Template/LoginRegister/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/daterangepicker/moment.min.js"></script>
    <script src="~/Template/LoginRegister/vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="~/Template/LoginRegister/js/main.js"></script>
</body>
</html>
