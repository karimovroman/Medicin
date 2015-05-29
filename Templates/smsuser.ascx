<%@ Control Language="C#" AutoEventWireup="true" CodeFile="smsuser.ascx.cs" Inherits="Templates_smsuser" %>
<div class="accordion">
<h3><asp:Label ID="header" runat="server"></asp:Label><asp:Label ID="number" Visible="false" runat="server"></asp:Label></h3>
<div >
    <table>
        <tr>
            <td>
                <asp:Image id="image_p" runat="server" ImageUrl="p" Height="100px" Width="100px" />
            </td>
            <td style="vertical-align:top">                
                <div style="text-align:left; width: 100%; height:100%">
                    <asp:Label ID="about" runat="server" ></asp:Label>
                </div><br />
                <div style="text-align:right">
                    <asp:LinkButton ID="Link" runat="server" Text ="перейти" ></asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
</div></div>
