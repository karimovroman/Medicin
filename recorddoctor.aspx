<%@ Page Title="Записаться на прием: Выбор доктора" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="recorddoctor.aspx.cs" Inherits="Recorddoctor" %>
<%@ Reference Control="~/Templates/doctor.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        string specid = "", moid = "";
        HttpCookie cookie = Request.Cookies["medicin"];
        if (cookie != null)
        {
            specid = (cookie["specid"]);
            moid = cookie["moid"];

        }
        else
        {
            Response.Redirect("recordspec.aspx");
        }
        
        
        
        List<DBase.doctor> alldc = new List<DBase.doctor>();
        List<DBase.doctor> alld = new DBase.MSSQL().GetAllDoctors();
        
        List<DBase.mo> mos = new DBase.MSSQL().GetMo();
        
        foreach (DBase.doctor d in alld)
        {
            if (d.Idspec == Convert.ToInt32(specid) && d.Mo == moid )
            {
                alldc.Add(d);
            }
        }

        if (alldc.Count() > 0)
        {
            foreach (DBase.doctor d in alldc)
            {
                Templates_doctor cntrl = (Templates_doctor)LoadControl("Templates/doctor.ascx");
                cntrl.Name_spec = d.Sur + " " + d.Name + " " + d.Mid;
                cntrl.Id_spec = Convert.ToString(d.Id);
                cpecialisti.Controls.Add(cntrl);
            }
        }
        else if (alldc.Count() == 0)
        {
            MultiView1.Visible = false;
            info.Text = "Нет врачей выбраной специализации"+" <a href='recordspec.aspx'>Вернуться</a>";
            
        } 
        
    }   
</script>
    <asp:Label ID="info" runat="server" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" >
        <asp:View ID="spec" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
            <td><h1>Для записи выберите доктора</h1></td>
         </tr> 
            
         <asp:PlaceHolder ID="cpecialisti" runat="server"></asp:PlaceHolder>
            <tr></tr>
        </table>

        </asp:View>
        <asp:View ID="Name" runat="server">


        </asp:View>
        <asp:View ID="calendar" runat="server">


        </asp:View>
    </asp:MultiView>
   

        
    
    
</asp:Content>

