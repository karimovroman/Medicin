<%@ Page Title="Регистратура: Отчеты по врачам" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="doctorreport.aspx.cs" Inherits="doctorreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <table>
        <tr>
            <td>Выберите сотрудника 
                <asp:DropDownList ID="doctorlist" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr style="margin-top:50px">
            <td>Специализация сотрудника 
                <asp:Label ID="special" runat="server"></asp:Label>
            </td>
        </tr>
        <tr style="margin-top:50px">
            <td>Должность сотрудника 
                <asp:Label ID="dolgnost" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="h1" runat="server"><h1>Востребованность специалиста</h1><br />

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
        <tr id="h2" runat="server">
            <td>Часы работы сотрудника:
                <asp:Label ID="zapcount" runat="server"></asp:Label><br />
                Количество записей:
                <asp:Label ID="succount" runat="server"></asp:Label><br />
            </td>
        </tr>
        
    </table>
</asp:Content>

