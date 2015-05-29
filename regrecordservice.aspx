<%@ Page Title="Записи на услуги" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="regrecordservice.aspx.cs" Inherits="regrecordservice" %>

<%@ Reference Control="~/Templates/services.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script runat="server">
       
    </script>


    <div style="">

       
        <table>
            <tr>
                <td style="">
                    <h1><asp:Label id="zagol" runat="server" Text="Записи на оказание услуг:"></asp:Label></h1>
                </td>
               
            </tr>
             <tr style="text-align: center">
                <td style="">
                    <div runat="server">
                        <asp:PlaceHolder ID="zaplist" runat="server"></asp:PlaceHolder>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

