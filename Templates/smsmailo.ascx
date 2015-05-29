<%@ Control Language="C#" AutoEventWireup="true" CodeFile="smsmailo.ascx.cs" Inherits="Templates_smsmailo" %>
<div class="accordion" style="margin-left:10px">
<h3><asp:Label ID="header" runat="server"></asp:Label><asp:Label ID="number" Visible="false" runat="server"></asp:Label></h3>
<div style="text-align:left">
    <table>
        <tr>
            <td>
                Вы:<asp:Label ID="message" runat="server" ></asp:Label><br />
                <asp:Label ID="time" runat="server" Font-Size="XX-Small"></asp:Label>
            </td>
        </tr>
    </table>
</div></div>
