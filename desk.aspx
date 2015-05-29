<%@ Page Title="Регистратура" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="desk.aspx.cs" Inherits="desk" %>
<%@ Reference Control="~/Templates/zapros.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p></p>
    <table>
        <tr>
            <td colspan="2">
                <div><asp:Label ID="zagol" runat="server"></asp:Label>
                    <asp:PlaceHolder ID="zapros" runat="server"></asp:PlaceHolder>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
                 <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'" >
                    <h3>Запись на прием к врачу</h3>
                    <p class="lead">Система предназначена для записи пациента на прием к врачу</p>
                    <p><a href="regrecordpatient.aspx" class="bgy" style="font-size:12px" >> Записать</a></p>
                </div>
            </td>
            <td style="width:50%">
          
    <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Новый пациент</h3>
        <p class="lead">Внесение данных новых пациентов</p>
        <p><a href="regpatients.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>
        <p></p>
        <tr>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Пациенты</h3>
        <p class="lead">Просмотр и редактирование данных пациентов.</p>
        <p><a href="reglistpatient.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
            <td  style="width:50%">
                <div class="jumbotron" onmouseover="this.style.backgroundColor='#fffeee'" onmouseout="this.style.backgroundColor='#EEEEEE'">
        <h3>Отчеты</h3>
        <p class="lead">Сформировать отчеты</p>
        <p><a href="deskreports.aspx" class="bgy" style="font-size:12px" >> Перейти</a></p>
    </div>
            </td>
        </tr>
    </table>
   
    <p></p>
</asp:Content>

