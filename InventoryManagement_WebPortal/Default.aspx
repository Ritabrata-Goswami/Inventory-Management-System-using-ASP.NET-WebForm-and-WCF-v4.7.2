<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inventory Management System</title>
    <style type="text/css">
        body{
            font-family:Arial, Helvetica, sans-serif;
            background-color:#f1f1f1;
        }
        .Header-Container{
            margin-top:10px;
            text-align:center;
        }
        .Parent-Form-Container{
            margin-top:100px;
            display:flex;
            flex-direction:column;
            align-items:center;
            justify-content:center;
        }
        .Child-Form-Container{
            width:500px;
        }
        .Message-Container{
            margin-bottom:10px;
            text-align:center;
        }
        .Server-Msg{
            font-size:16px; 
            color:#e81313; 
            font-weight:bold;
        }
        .fld-container{
            margin-bottom:8px;
            display:flex;
            flex-direction:row;
        }
        span{
            font-weight:bold;
            width:20%;
        }
        .input-fld{
            padding:5px 5px;
            font-size:17px;
            border-radius:3px;
            border:1px solid #808080;
            width:80%;
        }
        .btn-container{
            margin-top:18px;
        }
        .Login-Btn{
            padding:8px 8px;
            font-size:17px;
            background-color:#3284f3;
            color:white;
            cursor:pointer;
            border:none;
            border-radius:3px;
            width:100%;
        }
        .Login-Btn:hover{
            transition:0.3s;
            background-color:#0a53e8;
        }
    </style>
</head>
<body>
    <div class="Header-Container">
        <h2>Inventory Management System</h2>
    </div>
    <form id="form1" runat="server" class="Parent-Form-Container">
        <div class="Child-Form-Container">
            <div class="Message-Container">
                <asp:Label ID="servermessage" runat="server" CssClass="Server-Msg" />
            </div>
            <div class="fld-container">
                <span>User Id: </span>
                <asp:TextBox ID="userid" runat="server" placeholder="Enter user id" CssClass="input-fld"/>
            </div>
            <div class="fld-container">
                <span>Password: </span>
                <asp:TextBox TextMode="Password" ID="userpass" runat="server" placeholder="Enter user password" CssClass="input-fld" />
            </div>
            <div class="btn-container">
                <asp:Button runat="server" ID="submit" Text="Login" CssClass="Login-Btn" OnClick="Login_Event"/>
            </div>
        </div>
        
    </form>
</body>
</html>
