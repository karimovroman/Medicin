<%@ Control Language="C#" AutoEventWireup="true" CodeFile="servicetime.ascx.cs" Inherits="Templates_servicetime" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    public void record_Click(Object sender, ImageClickEventArgs e)
    {
        HttpCookie cookie = new HttpCookie("servicetime");
        cookie["regservtime"] = times.Text; ;
        cookie["regservdata"] = datazap.Text;

        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/servicepoint.aspx");
    }


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
<table>
<tr>
    <td style="text-align:center">
        <div runat="server" onclick="times_Click">
            <asp:LinkButton ID="times" OnClick="times_Click"  Text="" runat="server"></asp:LinkButton>
            <asp:Label ID="datazap" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="month" runat="server" Visible="false"></asp:Label>
        </div>
    </td>
</tr>
</table>