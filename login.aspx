<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>


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
            protected void log(object sender, EventArgs e)
            {
                string login = email.Value;
                string password = passwd.Value;
                string typeuser = "";
                string url = "";
                if (user.Checked)
                {
                    typeuser = "user";
                    url = "~/Patient.aspx";
                }
                if (doctr.Checked)
                {
                    typeuser = "doctor";
                    
                    url = "~/Workstop.aspx";
                }
                if (regstr.Checked)
                {
                    typeuser = "registr";
                    url = "~/Desk.aspx";
                }
                try
                {
                    DBase.MSSQL mssql = new DBase.MSSQL();
                    List<string> otv = mssql.Login(login,password,typeuser);
                    HttpCookie cookie = new HttpCookie("user");

                  
                   
                           cookie["iduser"] = otv[0]; //member.Fio;
                           cookie["fiouser"] = otv[1]; //memberDB.GetMemberRole(member.MemberID);
                           cookie["typeuser"] = typeuser;
                            cookie.Expires = DateTime.Now.AddHours(9);
                           Response.Cookies.Add(cookie);

                           Response.Redirect(url);
                          
                    
                       
                      
                    }
                    catch {  }


            }
            
        </script>
     <div class="container">

      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Войдите сейчас</h2>
          <div style="color:#2F4F4F ">
             <input id="user" name="log" class="checkbox" runat="server"  type="radio" checked="true" />Пациент<br />
             <input id="doctr" name="log" class="checkbox" runat="server" type="radio" />Доктор<br />
             <input id="regstr" name="log" class="checkbox" runat="server" type="radio" />Сотрудник регистратуры<br />
        </div>
              <p></p>
          <input runat="server" id="email" type="text" class="input-block-level" placeholder="Email">
        <input runat="server" id="passwd" type="password" class="input-block-level" placeholder="Пароль">
        
             

        <div id="alertshow" class="hidden" runat="server">
            <a class="close" data-dismiss="alert" href="#">x</a>Неправильный email или пароль!
        </div>  
        <asp:Button runat="server" id="loginbtn" class="btn btn-large btn-primary"  Text="Войти" OnClick="log" />
      </form>

    </div>
</body>
</html>

