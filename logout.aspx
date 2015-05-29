<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Вход на сайт</title>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <link href="css/bootstrap.css" rel="stylesheet">
    <script type="text/javascript" src="jscript/jquery-1-4-2.js"></script>
    <style type="text/css">
      body {
        padding-top: 40px;
        padding-bottom: 40px;
        background-color: #f5f5f5;
      }

      .form-signin {
        max-width: 300px;
        padding: 19px 29px 29px;
        margin: 0 auto 20px;
        background-color: #fff;
        border: 1px solid #e5e5e5;
        -webkit-border-radius: 5px;
           -moz-border-radius: 5px;
                border-radius: 5px;
        -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.05);
           -moz-box-shadow: 0 1px 2px rgba(0,0,0,.05);
                box-shadow: 0 1px 2px rgba(0,0,0,.05);
      }
      .form-signin .form-signin-heading,
      .form-signin .checkbox {
        margin-bottom: 10px;
      }
      .form-signin input[type="text"],
      .form-signin input[type="password"] {
        font-size: 16px;
        height: auto;
        margin-bottom: 15px;
        padding: 7px 9px;
      }

    </style>
    <link href="css/bootstrap-responsive.css" rel="stylesheet" />

</head>
<body >
        <script runat="server">
          
            
        </script>
     <div class="container">

      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Выход из системы!</h2>
          <asp:UpdateProgress ID="UpdateProgress1" runat="server"></asp:UpdateProgress>
        <div id="alertshow" class="hidden" runat="server">
            <a class="close" data-dismiss="alert" href="#">x</a>Неправильный email или пароль!
        </div>  
         </form>

    </div>
</body>
</html>

