<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_v4" %>
<!DOCTYPE html>

<html>
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="shortcut icon" href="data:image/x-icon;," type="image/x-icon"> 
    <title>Login Page</title>
    <link href="resources/custom/login/login.css" rel="stylesheet" />
     <script src="../resources/plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../resources/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="../resources/plugins/login-js/dist/sweetalert2.all.min.js"></script>
<script type="text/javascript">
        $(document).ready(function () {
            $('[id*=btnLogin]').on('click', function () {
                var UName = document.getElementById('txtUserName');
                var Password = document.getElementById('txtPassword');
                if ((UName.value == '') || (Password.value == '')) {
                    UpdateAlert();
                    return false;
                }
                else {
                    return true;
                }

            });
        });
        function UpdateAlert() {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your username and password; the fields cannot be left blank.',
            })
        }
        function WarningAlert() {
            Swal.fire({
                icon: 'warning',
                title: 'Oops...',
                text: 'User ID or Password is incorrect. Please check again.',
            })
        }

    </script>
</head>
    
<body class="text-center">
    <form id="form1" runat="server">
    
        <div class="login-box">
            <image src="resources/img/bg.png" width="283px" height="105px" style="position: relative; top: -150px;"></image>
            <div class="user-box">
                <%--<input type="text" id="textUsername" name="textUsername" required="" runat="server"/>--%>
                <asp:TextBox ID="txtUserName" name="txtUserName" runat="server" style="margin-left:80px;"></asp:TextBox>
            </div>
            <div class="user-box">
                <%--<input type="password" id="textPassword" name="textPassword" required="" runat="server"/>--%>
                <asp:TextBox ID="txtPassword" name="txtPassword" TextMode="Password" runat="server" style="margin-left:80px"></asp:TextBox>
            </div>
            <a>
                <span></span>
                <span></span>
                <span></span>
                <span></span>

                <asp:Button ID="btnLogin" CssClass="btn btn-primary" Text="LOGIN" OnClick="btnLogin_Click" runat="server" />
            </a>
           
        </div>
        <div class="row">
             <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#FF3300"/>
        </div>
         
    </form>
</body>
</html>
