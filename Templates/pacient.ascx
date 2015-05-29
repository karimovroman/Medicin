<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pacient.ascx.cs" Inherits="Templates_pac" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            menush.Visible = false;
        }
    }
    protected void edit_Click(object sender, ImageClickEventArgs e)
    {
        if (menush.Visible == false)
            menush.Visible = true;
        else
            menush.Visible = false;
    }
    protected void osmotr_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("patient");
        cookie["idpatient"] = Id.Text;
        cookie.Expires = DateTime.Now.AddMinutes(3); ;
        Response.Cookies.Add(cookie);
        Response.Redirect("visits.aspx");

    }
    protected void isledov_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("patient");
        cookie["idpatient"] = Id.Text;
        cookie.Expires = DateTime.Now.AddMinutes(3); ;
        Response.Cookies.Add(cookie);
        Response.Redirect("researchs.aspx");

    }
    protected void metriki_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("patient");
        cookie["idpatient"] = Id.Text;
        cookie.Expires = DateTime.Now.AddMinutes(3); ;
        Response.Cookies.Add(cookie);
        Response.Redirect("metrics.aspx");
    }
    protected void recepts_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("patient");
        cookie["idpatient"] = Id.Text;
        cookie.Expires = DateTime.Now.AddMinutes(3); ;
        Response.Cookies.Add(cookie);
        Response.Redirect("recepts.aspx");
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
<tr>
<td>
    <div class="tContent" runat="server">
        <span class="p17 blueText">
            <asp:Label ID="FIO" runat="server" Text="ФИО  "></asp:Label><asp:ImageButton ID="edit" OnClick="edit_Click" ImageUrl="~/images/edit.png" runat="server" />
            <asp:Label ID="Id" runat="server" Visible="false" ></asp:Label>
    </span>
        </div>
    <div id="menush" runat="server" visible="false">
        <asp:LinkButton ID="osmotr" runat="server" OnClick="osmotr_Click" Text="Осмотр"></asp:LinkButton>
        <asp:LinkButton ID="isledov" runat="server" OnClick="isledov_Click" Text="Исследования"></asp:LinkButton>
        <asp:LinkButton ID="metriki" runat="server" OnClick="metriki_Click" Text="Метрики"></asp:LinkButton>
        <asp:LinkButton ID="recepts" runat="server" OnClick="recepts_Click" Text="Рецепт"></asp:LinkButton>
    <asp:LinkButton ID="emks" runat="server" OnClick="emks_Click" Text="ЭМК"></asp:LinkButton>
    
    </div>
                            

</td>
</tr>