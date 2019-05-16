<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Medical_Corporation_Hospital.Authentication.Register" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css"/>

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">

            <h4>Register a new user</h4>
           
            <p>
                <asp:Literal runat="server" ID="StatusMessage"/>
            </p>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                <div>
                    <asp:TextBox  class="form-control" runat="server" ID="UserName"/>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <div>
                    <asp:TextBox class="form-control" runat="server" ID="Password" TextMode="Password"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <div>
                    <asp:TextBox class="form-control" runat="server" ID="ConfirmPassword" TextMode="Password"/>
                </div>
            </div>
            <div>
                <div>
                    <asp:Button type="submit" class="btn btn-primary" runat="server" OnClick="CreateUser_Click" Text="Register"/>
                </div>
            </div>

        </form>
    </div>
</body>
</html>