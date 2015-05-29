<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="passwordchange.aspx.cs" Inherits="passchange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="login" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
     <script runat="server">
        private DBase.MSSQL mssql = new DBase.MSSQL();    
        private int r = 0;
        
      void Page_Load(Object sender, EventArgs e)
      {
         
         }
      protected void ok_Click(object sender, EventArgs e)
      {
          if(pasword.Text == passwordtoo.Text)
          {
          DBase.MSSQL mssql = new DBase.MSSQL();
          string login = loginuser.Text;
          string password = oldpass.Text;
          string url = "";
          string typeuser = "";
          List<string> otv = new List<string>();
          if (mssql.Login(login, password, "user").Count != 0)
          {
              typeuser = "user";
              otv = mssql.Login(login, password, typeuser);
              url = "~/Patient.aspx";
          }
          if (mssql.Login(login, password, "doctor").Count != 0)
          {
              typeuser = "doctor";
              otv = mssql.Login(login, password, typeuser);

              url = "~/Workstop.aspx";
          }
          if (mssql.Login(login, password, "registr").Count != 0)
          {
              typeuser = "registr";
              otv = mssql.Login(login, password, typeuser);

              url = "~/Desk.aspx";
          }
          int res = 0;
              if(otv.Count >0)
          if(otv[0]!="0")
          { 
            res = mssql.UpdatePassword(typeuser, Convert.ToInt32(otv[0]), password, passwordtoo.Text);
          }
          if(res != 0)
          {
                           
              if (res == 1)
              {
                  DBase.predstavitel pred = mssql.GetPatientPredstavitel(Convert.ToInt32(otv[0]));
                  Email.Email email = new Email.Email();
                  email.SendEmailGmail("mail@medic.med", pred.Phone2,"Смена пароля", "Ваш пароль изменен!");
              
                  HtmlGenericControl message = new HtmlGenericControl();
                  message.InnerHtml = "<h5 style='color: Green'>Ваш пароль изменен! </h5>";
                  mas.Controls.Add(message);
              }
              if (res == 2)
              {
                  Email.Email email = new Email.Email();
                  email.SendEmailGmail("mail@medic.med", loginuser.Text, "Смена пароля", "Ваш пароль изменен!");
              
                  HtmlGenericControl message = new HtmlGenericControl();
                  message.InnerHtml = "<h5 style='color:  Green'>Ваш пароль изменен! </h5>";
                  mas.Controls.Add(message);
              }
              if (res == 3)
              {
                  Email.Email email = new Email.Email();
                  email.SendEmailGmail("mail@medic.med", loginuser.Text, "Смена пароля", "Ваш пароль изменен!");
              
                  HtmlGenericControl message = new HtmlGenericControl();
                  message.InnerHtml = "<h5 style='color:  Green'>Ваш пароль изменен! </h5>";
                  mas.Controls.Add(message);
              }
          }
          if(res == 0)
          {
              HtmlGenericControl message = new HtmlGenericControl();
              message.InnerHtml = "<h5 style='color: Red'>Ошибка смены пароля! Обратитеть к администратору! </h5>";
              mas.Controls.Add(message);
          }
              }
      }
       
     </script>
    <div id="mas" runat="server"></div>
    <table>
        <tr>
            <td>
                Введите логин:
            </td>
            <td>
                <asp:TextBox ID="loginuser" runat="server" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Введите cтарый пароль:
            </td>
            <td>
                <asp:TextBox ID="oldpass" runat="server" TextMode="Password" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Введите новый пароль:
            </td>
            <td>
                <asp:TextBox ID="pasword" runat="server" TextMode="Password" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Введите подтверждение пароля:
            </td>
            <td>
                <asp:TextBox ID="passwordtoo" runat="server" TextMode="Password" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="ok" runat="server" OnClick="ok_Click" Text="Изменить"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>

