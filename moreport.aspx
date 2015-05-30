<%@ Page Title="Регистратура: Отчеты по медицинским учреждениям" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="moreport.aspx.cs" Inherits="moreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table>
        <tr>
            <td>Выберите медицинское учреждения для отображения
                <asp:DropDownList ID="molist" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Записи на прием<br />

                <asp:Chart ID="Chart1" runat="server" Width="400px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom"
                            IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" ChartType="Pie" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"
                            BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td>Количество записей на прием:
                <asp:Label ID="zapcount" runat="server"></asp:Label><br />
                Количество посещений по записи на прием:
                <asp:Label ID="succount" runat="server"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>Записи на оказание платных услуг<br />

                <asp:Chart ID="Chart2" runat="server" Width="400px">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom"
                            IsTextAutoFit="False" Name="Default"
                            LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Default" ChartType="Pie" />
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"
                            BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td>Количество записей :
                <asp:Label ID="servcount" runat="server"></asp:Label><br />
                Количество подтвержденных:
                <asp:Label ID="servsuccount" runat="server"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

