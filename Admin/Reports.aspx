<%@ Page Title="Панель администрирования: Информация о системе" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Admin_reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="width:100%">
        <tr>
            <td style="width:50%">
                <table title="Данные о записях">
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <h4>Данные о записях</h4>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">№
                        </td>
                        <td style="width: 300px">Название обьекта
                        </td>
                        <td style="width: 50px">Кол-во
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">1
                        </td>
                        <td style="width: 300px">Пациенты
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="patient" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">2
                        </td>
                        <td style="width: 300px">Врачи
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="doct" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">3
                        </td>
                        <td style="width: 300px">Лекарственные средства
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="lekrs" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">4
                        </td>
                        <td style="width: 300px">Специальности врача
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="specis" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">5
                        </td>
                        <td style="width: 300px">Диагнозы
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="diagnoz" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">6
                        </td>
                        <td style="width: 300px">Медицинские учреждения
                        </td>
                        <td style="width: 50px">
                            <asp:Label ID="mois" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:50%">
                <table title="Данные о БД" style="margin-top: 20px">
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <h4>Данные о БД</h4>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">1
                        </td>
                        <td style="width: 300px">MSSQL
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="ms" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">2
                        </td>
                        <td style="width: 300px">MySQL
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="my" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">3
                        </td>
                        <td style="width: 300px">Количество таблиц MS SQL
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="Label3" runat="server" Text="32"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30px">4
                        </td>
                        <td style="width: 300px">Количество таблиц MySQL
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="Label1" runat="server" Text="8"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>




</asp:Content>

