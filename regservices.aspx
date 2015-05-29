<%@ Page Title="Платные услуги. Выбор времени" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="regservices.aspx.cs" Inherits="regservices" %>
<%@ Reference Control="~/Templates/timer.ascx" %>
<%@ Reference Control="~/Templates/servicetime.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    
    
</script>
   
          <table  style="width:350px">
              <tr>
                  <td style="width:50%">
                      <asp:LinkButton ID="prev"   Text ="< пред. неделя" OnClick="prev_Click" runat="server"></asp:LinkButton>
                  </td>
                  <td style="width:50%;text-align:right">
                      <asp:LinkButton ID="next"  Text ="след. неделя >" OnClick="next_Click" runat="server"></asp:LinkButton>
                  </td>
              </tr>
          </table>
         
          <h1><asp:Label ID="month" runat="server"></asp:Label>
              <asp:Label ID="daycontr" runat="server" Visible="false" Text="7"></asp:Label>
            </h1> 
            <table >
                <tr>
                    <td style="width: 50px">
                        <h1>ПН</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>ВТ</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>СР</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>ЧТ</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>ПТ</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>СБ</h1>
                    </td>
                    <td style="width: 50px">
                        <h1>ВС</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h1>
                            <asp:Label ID="ch1" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch2" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch3" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch4" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch5" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch6" runat="server"></asp:Label></h1>
                    </td>
                    <td>
                        <h1>
                            <asp:Label ID="ch7" runat="server"></asp:Label></h1>
                    </td>
                </tr>

                <tr style="text-align:center">
                    <td style="width: 50px">
                        <div runat="server">
                        <asp:PlaceHolder ID="pn" runat="server"></asp:PlaceHolder>
                            </div>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="vt" runat="server"></asp:PlaceHolder>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="sr" runat="server"></asp:PlaceHolder>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="ht" runat="server"></asp:PlaceHolder>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="pt" runat="server"></asp:PlaceHolder>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="sb" runat="server"></asp:PlaceHolder>
                    </td>
                    <td style="width: 50px">
                        <asp:PlaceHolder ID="vs" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
            </table> 
</asp:Content>


