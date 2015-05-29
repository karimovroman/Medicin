<%@ Page Title="Панель администрирования" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
     
    </script>

    <div class="jumbotron">
        <div style="text-align:center;font-size:20px"><h1>Панель администрирования</h1></div>
        <p class="lead" style="text-align:left;font-size:20px">    Состояние базы MS SQL: <asp:Label ID="mssql" runat="server"></asp:Label></p>
        <p class="lead" style="text-align:left;font-size:20px">    Состояние базы MYSQL: <asp:Label ID="mysql" runat="server"></asp:Label></p>
        <p class="lead" style="text-align:left;font-size:20px">    Для добавления записей в справочники mysql перейдите в &quot;Справочники&quot;</p>
        <p class="lead" style="text-align:left;font-size:20px">    Для добавления пользователей перейдите в &quot;Пользователи&quot;</p>
        <p></p>
    </div>
</asp:Content>

