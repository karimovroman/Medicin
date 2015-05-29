<%@ Control Language="C#" AutoEventWireup="true" CodeFile="services.ascx.cs" Inherits="Templates_services" %>
<script runat="server">
</script>

<style type="text/css">
    .cardFile.profile {
margin: 0 0 5px 0;
}
.cardFile {
min-height: 50px;
border: 1px solid #FFF;
position: relative;
margin: 15px 0;
}
.tContent {
-webkit-background-clip: border-box;
-webkit-background-origin: padding-box;
-webkit-background-size: auto;
-webkit-box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
background-attachment: scroll;
background-clip: border-box;
background-color: rgba(0, 0, 0, 0);
background-image: url(https://doctor30.ru/design/common/img/cardContentbox.jpg);
background-origin: padding-box;
background-size: auto;
border-bottom-color: rgb(236, 236, 236);
border-bottom-left-radius: 10px;
border-bottom-right-radius: 10px;
border-bottom-style: solid;
border-bottom-width: 1px;
border-image-outset: 0px;
border-image-repeat: stretch;
border-image-slice: 100%;
border-image-source: none;
border-image-width: 1;
border-left-color: rgb(236, 236, 236);
border-left-style: solid;
border-left-width: 1px;
border-right-color: rgb(236, 236, 236);
border-right-style: solid;
border-right-width: 1px;
border-top-color: rgb(236, 236, 236);
border-top-left-radius: 10px;
border-top-right-radius: 10px;
border-top-style: solid;
border-top-width: 1px;
box-shadow: rgba(0, 0, 0, 0.298039) -3px 2px 4px 0px;
clear: both;
color: rgb(0, 0, 238);
cursor: auto;
display: block;
font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif;
height: 30px;
margin-bottom: 5px;
margin-left: 0px;
margin-right: 0px;
margin-top: 5px;
outline-color: rgb(0, 0, 238);
outline-style: none;
outline-width: 0px;
padding-bottom: 5px;
padding-left: 10px;
padding-right: 10px;
padding-top: 5px;
text-decoration: none;
width: 331px;
}

</style>
<table style="margin-bottom: 10px">
    <tr>
        <td style="width: 10px">

            <asp:Image ID="il" runat="server" ImageUrl="~/images/in.png" Width="10px" />

        </td>
        <td style="width: 50px">
            <asp:Label ID="time" runat="server" Text="Время"></asp:Label>
            <asp:Label ID="idservtime" runat="server" Visible="false"></asp:Label>
        </td>
        <td style="width: 400px">
            <asp:Label ID="fio" runat="server" Text="FIO"></asp:Label>
            <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="pacid" runat="server" Visible="false"></asp:Label>
        </td>
         <td id="success" runat="server" style="width: 50px">
            <asp:ImageButton ID="yes" runat="server" OnClick="yes_Click" ImageUrl="~/images/yes.png"></asp:ImageButton>
           <asp:ImageButton ID="no" runat="server" OnClick="no_Click" ImageUrl="~/images/no.png"></asp:ImageButton>
           
        </td>
        <td style="width: 100px">
            <asp:LinkButton ID="kvitanc" runat="server" OnClick="kvitanc_Click" Text="Квитанция"></asp:LinkButton>
           
        </td>
        <td style="width: 100px">
             <asp:LinkButton ID="dogovor" runat="server" OnClick="dogovor_Click" Text="Договор"></asp:LinkButton>

        </td>
    </tr>
</table>