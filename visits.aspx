<%@ Page Title="Осмпотры пациента: Новый осмотр" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="visits.aspx.cs" Inherits="visits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script runat="server">
    
    
    
    
    </script>

    <div>
        <asp:Label ID="information" runat="server"></asp:Label>
        <table runat="server" id="inform">
            <tr>
                <td colspan="2" style="text-align: center">Заполните поля:
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Width="150px" Text="Симптомы, жалобы:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="300px" TextMode="MultiLine" Height="50" ID="simptom" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Результат осмотра:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="300px" TextMode="MultiLine" Height="50" ID="result" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Поставлен диагноз:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="diagnoz" Width="300px" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" Text="Комментарии:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="300px" TextMode="MultiLine" Height="50" ID="about" runat="server"></asp:TextBox>
                </td>
            </tr>


        </table>



        <div id="novorojd" runat="server">
            <table runat="server" id="Table1">
                <tr>
                    <td colspan="2" style="text-align: center">Заполните поля:
                    <asp:Label ID="idosmotr" Text="" Visible="false" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr align="left">
                    <td>День жизни:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="den" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Температура тела:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="temp" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Вес тела:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="vestela" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Динамика массы тела:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="dinamica" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Состояние:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="sost" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Видимые пороки развития:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="poroki" runat="server"></asp:TextBox>
                        &nbsp;</td>
                </tr>

                <tr align="left">
                    <td>Малые пороки развития:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="minporoki" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Поза:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="poza" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Мышечный тонус:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="tonys" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Рефлексы:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="refleks" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>ЧСС (уд/мин):</td>
                    <td>
                        <asp:TextBox Width="300px" ID="chastota" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Дыхание при рождении:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="dihan" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Половые признаки:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="pol" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Жалобы матери:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="jalob" runat="server"></asp:TextBox></td>
                </tr>
                <tr align="left">
                    <td>Заболевания новорожденного:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="zabolev" runat="server"></asp:TextBox></td>
                </tr>
                <tr align="left">
                    <td>Доп. результаты:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="dop" runat="server"></asp:TextBox></td>
                </tr>
                <tr align="left">
                    <td>Особености при осмотре:</td>
                    <td>
                        <asp:TextBox Width="300px" ID="osoben" runat="server"></asp:TextBox></td>
                </tr>

                <tr align="left">
                    <td>Комментарии:</td>
                    <td>
                        <asp:TextBox Width="300px" TextMode="MultiLine" ID="comm" runat="server"></asp:TextBox></td>
                </tr>

            </table>

        </div>
        <div>
            <br />
            <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Осмотр новорожденного" runat="server" />
            <asp:Button ID="save" runat="server" OnClick="SaveMyInformation" CssClass="logo" Text="Сохранить результаты" />
        </div>


    </div>



</asp:Content>

