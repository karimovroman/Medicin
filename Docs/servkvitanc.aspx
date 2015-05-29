<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servkvitanc.aspx.cs" Inherits="Docs_servkvitanc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="text-align:center;width:100%">
            <tr>
                <td>
                    <asp:Label ID="_namemo" runat="server"></asp:Label>,<asp:Label ID="_address" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><h3>
                    Справка №<asp:Label ID="_numb" runat="server"></asp:Label>
                </td></h3>
            </tr>
             <tr>
                <td>
                    <b>о стоимости медицинской помощи, оказанной застрахованному лицу в рамках программы обязательного медицинского страхования</b>
                </td>
            </tr>
        </table>
        <table style="width:100%">
            <tr style="text-align:right">
                <td>
                    от<asp:Label ID="_date" runat="server"></asp:Label>
                </td>
            </tr>
             <tr >
                <td>
                    Выдана (Ф.И.О.)<asp:Label ID="_fio" runat="server"></asp:Label>
                </td>
            </tr>
            <tr >
                <td>
                    в том, что (Ф.И.О.)<asp:Label ID="_fio2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="_date2" runat="server"></asp:Label> оказана услуга:
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="_names" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr >
                <td>
                    Стоимость медицинской помощи составила <asp:Label ID="_cost" runat="server"></asp:Label> 
                </td>
            </tr>
            <tr style="text-align:right">
                <td>
                    Финансовый директор _______________ <asp:Label id="_lico" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
