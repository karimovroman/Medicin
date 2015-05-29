<%@ Page Title="Платные услуги" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="services.aspx.cs" Inherits="services" %>
<%@ Reference Control="~/Templates/service.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {

        HttpCookie cookie = new HttpCookie("medicin");
        cookie["serviceid"] = "";
       
        
        //member.Fio;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
       // Response.Redirect("");
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.service> serv = mssql.GetServices();
        string str = "<tr><td colspan=\"3\" style=\"text-align:center\">Прайс-лист<//td><//tr>";
        int num = 1;
        foreach (DBase.service n in serv)
            {
                Templates_service cntrl = (Templates_service)LoadControl("Templates/service.ascx");
                cntrl.Name_serv = n.Name;
                cntrl.About = n.About;
                cntrl.Id_serv = Convert.ToString(n.Id);
                cntrl.Cost = n.Cost;
                servicesplace.Controls.Add(cntrl);
                str += "<tr><td style=\"text-align:center\">" + Convert.ToString(num) + "<//td><td style=\"text-align:center\">" + Convert.ToString(n.Name) + "<//td><td style=\"text-align:center\">"+Convert.ToString(n.Cost)+"руб.<//td><//tr>";
                num += 1;
            }
        price.Text = str;
        
    }   
</script>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

        <asp:View ID="spec" runat="server">
          
                    <asp:LinkButton ID="show" OnClick="shower" runat="server" Text="Показать прайс-лист"></asp:LinkButton>
                <table style="width: 400px">
                    <asp:Label ID="price" runat="server" Visible="false"></asp:Label>
                </table>
            
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <h1>Для записи выберите услугу из перечня</h1>
                    </td>
                </tr>

                <asp:PlaceHolder ID="servicesplace" runat="server"></asp:PlaceHolder>
            </table>

        </asp:View>

    </asp:MultiView>
   

 
</asp:Content>


