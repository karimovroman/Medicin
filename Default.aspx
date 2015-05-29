<%@ Page Title="Главная" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="loginpanel" ContentPlaceHolderID="login" runat="server">
    
                            <div ID="Login2" visible="false" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333">
                                
                                    <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                                        <tr>
                                            <td>
                                                <table cellpadding="0">
                                                    <tr>
                                                        <td align="center" colspan="2" style="color:White;background-color:#507CD1;font-size:0.9em;font-weight:bold;">Вход</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Логин:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl14$Login2">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Пароль:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl14$Login2">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td align="center" colspan="2" style="color:Red;">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" OnClick="LoginButton_Click" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Text="Войти" ValidationGroup="ctl14$Login2" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                               
                                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                                <TextBoxStyle Font-Size="0.8em" />
                                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                            </div>
                       
</asp:Content>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script runat ="server">
        protected void test(object sender, EventArgs e)
        {
            
        }    
    </script>
    <p></p>
    <div class="jumbotron">
        <h2>Запись к врачу</h2>
        <p class="logo">  <img src="images/faq-icon.png" alt="?" style="height:20px" />  Для записи к врачу перейдите в раздел "Пациент"</p>
        <p class="logo">  <img src="images/faq-icon.png" alt="?" style="height:20px" />  Для доступа к рабочему месту врача перейдите в раздел "Врач"</p>
        <p class="logo"> <img src="images/faq-icon.png" alt="?" style="height:20px" />   Для доступа к кабинету регистратуры перейдите в раздел "Регистратура"</p>
        <p></p>
        
        <p class="logo"> <img src="images/faq-icon.png" alt="?" style="height:20px" />   Для регистрации в системе обратитесь в регистратуру медицинского учреждения по месту проживания.</p>

    </div>
    <div class="jumbotron" style="background-color:lightyellow;margin-top:10px">
        <p class="lead"><img runat="server" id="img1" src="images/alert.png" alt="?" style="height:20px; margin-right:10px" /><asp:Label runat="server" ID="Label1" Font-Size="X-Small" ></asp:Label></p>
        <p class="lead"><asp:Label runat="server" ID="Label2" Font-Size="X-Small" ></asp:Label></p>
    </div>

  
</asp:Content>
