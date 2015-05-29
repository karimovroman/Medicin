<%@ Page Title="Выбор пациента" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="regrecordpatient.aspx.cs" Inherits="Default2" %>
<%@ Reference Control="~/Templates/registrpatient.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        HttpCookie cookie = Request.Cookies["user"];
        int userid = Convert.ToInt32(cookie["iduser"]);
        int moid = mssql.GetRegistratorMO(userid);
        List<DBase.patient> pats = new DBase.MSSQL().GetAllPatient();
        if(IsPostBack)
        {
            cpecialisti.Controls.Clear();
            foreach (DBase.patient d in pats)
                if(d.Mo == moid)
            { 
                if (snils.Text != "")
                   if(d.Snils == snils.Text)
                        {

                            Templates_registrpatient cntrl = (Templates_registrpatient)LoadControl("Templates/registrpatient.ascx");
                            cntrl.Name_spec = d.Fam + " " + d.Im + " " + d.Otch;
                            cntrl.Id_spec = Convert.ToString(d.PatientID);
                           cpecialisti.Controls.Add(cntrl);

                       }
                if(snils.Text == "")
                {

                    Templates_registrpatient cntrl = (Templates_registrpatient)LoadControl("Templates/registrpatient.ascx");
                    cntrl.Name_spec = d.Fam + " " + d.Im + " " + d.Otch;
                    cntrl.Id_spec = Convert.ToString(d.PatientID);
                    cpecialisti.Controls.Add(cntrl);

                }
            }
                
            if (cpecialisti.Controls.Count == 0)
            {
               MultiView1.Visible = false;
                info.Text = "Нет пациентов. " + " <a href='desk.aspx'>Вернуться</a>";

            } 
        }
        if(!IsPostBack)
        { 
        string specid = "";
             
        
        foreach (DBase.patient d in pats)
            if (d.Mo == moid)
            { 
            
            if (snils.Text == "")
                {
                    {

                        Templates_registrpatient cntrl = (Templates_registrpatient)LoadControl("Templates/registrpatient.ascx");
                        cntrl.Name_spec = d.Fam + " " + d.Im + " " + d.Otch;
                        cntrl.Id_spec = Convert.ToString(d.PatientID);
                        cpecialisti.Controls.Add(cntrl);

                    }
                }
            }
                if (cpecialisti.Controls.Count == 0)
                {
                    MultiView1.Visible = false;
                    info.Text = "Нет пациентов. "+" <a href='desk.aspx'>Вернуться</a>";
            
                }
            }
    }   
</script>
    <asp:Label ID="info" runat="server" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" >
        <asp:View ID="spec" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
            <td><h1>Для записи выберите пациента или введите снилс:</h1></td>
         </tr> 
          <tr style="margin-bottom:25px">
            <td><asp:TextBox ID="snils" runat="server" Text=""></asp:TextBox> <asp:Button ID="search" CssClass="mbg" runat="server" OnClick="search_Click" Text="Найти" /></td>
         </tr> 
            <tr>
                <td>
                    <p>

                    </p>
                </td>
            </tr>
         <asp:PlaceHolder ID="cpecialisti" runat="server"></asp:PlaceHolder>
        </table>

        </asp:View>
        
    </asp:MultiView>
   

        
    
    
</asp:Content>
