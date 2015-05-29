<%@ Page Title="Регистратура: Выбор специальности" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="regrecordspec.aspx.cs" Inherits="regrecordspec" %>
<%@ Reference Control="~/Templates/regspecial.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {

        HttpCookie cookie = new HttpCookie("medicin");
        cookie["regspecid"] = "";
        cookie["regspecname"] = "";
        
        cookie["time"] = DateTime.Now.Date.ToShortTimeString() ; //member.Fio;
        cookie.Expires = DateTime.Now.AddHours(1);
       // Response.Cookies.Add(cookie);
       // Response.Redirect("");
        
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specs = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();
        specs = mysql.SelectSpecDoctor();

        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor n in specs)
            {
                Templates_regspecial cntrl = (Templates_regspecial)LoadControl("Templates/regspecial.ascx");
                cntrl.Name_spec = n.name;
                cntrl.Id_spec = Convert.ToString(n.id);
                cpecialisti.Controls.Add(cntrl);
            }
            
        
    }   
</script>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" >
        <asp:View ID="spec" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
            <td><h1>Для записи выберите специалиста</h1></td>
         </tr> 
         
         <asp:PlaceHolder ID="cpecialisti" runat="server"></asp:PlaceHolder>
        </table>

        </asp:View>
        <asp:View ID="Name" runat="server">


        </asp:View>
        <asp:View ID="calendar" runat="server">


        </asp:View>
    </asp:MultiView>
   

 
</asp:Content>

