<%@ Page Title="Метрики пациента: Добавить новые" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="metrics.aspx.cs" Inherits="metrics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

      <script runat="server">
       
     
        void SaveMyInformation(Object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["patient"];
            if (cookie != null)
            {
                pacid = cookie["idpatient"];
            }
            else
                Response.Redirect("pacients.aspx");
            HttpCookie cookiee = Request.Cookies["user"];
            if (cookiee != null)
            {
                if (cookiee["typeuser"] == "doctor")
                    docid = cookiee["iduser"];
            }
            DBase.MSSQL mssql = new DBase.MSSQL();
           
             
                    try
                    {
                        
                        
                        DBase.metrika metr = new DBase.metrika(0,Convert.ToInt32(pacid), okrgol.Text ,okrgrud.Text,okrtal.Text,temper.Text,chastota.Text,rost.Text,massa.Text,indeks.Text,sistol.Text,diastol.Text,puls.Text,about.Text,DateTime.Now.ToShortDateString(),Convert.ToInt32(docid));
                        int r = mssql.InsertMetrika(metr);
                        
                    }
                    catch(Exception ex)
                    {
                        string ttt = ex.Message;
       
                    }
                  
           
        }
    </script>


    <style type="text/css">
    .cardFile.profile {
margin: 0 0 5px 0;
}
.cardFile {
min-height: 50px;
border: 1px solid #FFF;
position: relative;
margin: 15px 0;
}
.tContent {
-webkit-background-clip: border-box;
-webkit-background-origin: padding-box;
-webkit-background-size: auto;
-webkit-box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
background-attachment: scroll;
background-clip: border-box;
background-color: rgba(0, 0, 0, 0);
background-image: url(https://doctor30.ru/design/common/img/cardContentbox.jpg);
background-origin: padding-box;
background-size: auto;
border-bottom-color: rgb(236, 236, 236);
border-bottom-left-radius: 10px;
border-bottom-right-radius: 10px;
border-bottom-style: solid;
border-bottom-width: 1px;
border-image-outset: 0px;
border-image-repeat: stretch;
border-image-slice: 100%;
border-image-source: none;
border-image-width: 1;
border-left-color: rgb(236, 236, 236);
border-left-style: solid;
border-left-width: 1px;
border-right-color: rgb(236, 236, 236);
border-right-style: solid;
border-right-width: 1px;
border-top-color: rgb(236, 236, 236);
border-top-left-radius: 10px;
border-top-right-radius: 10px;
border-top-style: solid;
border-top-width: 1px;
box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
clear: both;
color: rgb(0, 0, 238);
cursor: auto;
display: block;
font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;
height: 30px;
margin-bottom: 5px;
margin-left: 0px;
margin-right: 0px;
margin-top: 0px;
outline-color: rgb(0, 0, 238);
outline-style: none;
outline-width: 0px;
padding-bottom: 5px;
padding-left: 10px;
padding-right: 10px;
padding-top: 0px;
text-decoration: none;
width: 331px;
}
</style>



      <div>
        <table runat="server" id="inform">
            <tr >
                <td colspan="2" style="text-align:center">
                    Заполните поля:
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Окружность головы:"></asp:Label><asp:RegularExpressionValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="okrgol"
                                    ErrorMessage="Вы ввели не имя."
                                    ValidationExpression="[а-яА-Я]{1,50}" />
                                <asp:RequiredFieldValidator ForeColor="#ff3300" runat="server"
                                    ControlToValidate="okrgol" ValidationGroup="reg"
                                    ErrorMessage="Вы не ввели имя"> 
                                </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="okrgol" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Окружность груди:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="okrgrud" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Окружность талии:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="okrtal" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label runat="server" Text="Температура тела:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" id="temper" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Частота сердцебиения:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="chastota" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server"  Text="Рост:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="rost" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Масса тела:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="massa" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label runat="server" Text="Индекс массы тела:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="indeks" runat="server" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Систолическое давление:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="sistol" runat="server" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Диастолическое давление:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="diastol" runat="server" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Пульс:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" TextMode="Number" id="puls" runat="server" ></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Комментарии:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px" id="about" TextMode="MultiLine" Height="50" runat="server" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td colspan="2" style="text-align:right">
                    <br /><asp:Button ID="save" runat="server" OnClick="SaveMyInformation" CssClass="logo" Text="Сохранить результаты" />
                </td>
            </tr>



        </table>

    </div>



</asp:Content>

