<%@ Page Title="Мои пациенты" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true"  CodeFile="pacients.aspx.cs" Inherits="pacients" %>
<%@ Reference Control="~/Templates/pacient.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {

        DBase.MSSQL mssql = new DBase.MSSQL();
        string userid = "", username = "";
        HttpCookie cookie = Request.Cookies["user"];
        if (cookie != null)
        {
            string type = (cookie["typeuser"]);
            if (type == "doctor")
            {
                userid = cookie["iduser"];
                username = cookie["fiouser"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }

        List<DBase.doctor> docs = new DBase.MSSQL().GetAllDoctors();
       
        List<DBase.patient> pat = new DBase.MSSQL().GetAllPatient();
        foreach (DBase.doctor d in docs)
        {
            if(d.Id == Convert.ToInt32(userid))
            foreach (DBase.patient n in pat)
            {
                if (n.Mo == Convert.ToInt32(d.Mo))
                {
                    Templates_pac cntrl = (Templates_pac)LoadControl("Templates/pacient.ascx");
                    cntrl.Name_spec = n.Fam + " " + n.Im + " " + n.Otch;
                    cntrl.Id_spec = Convert.ToString(n.PatientID);
                    pacnts.Controls.Add(cntrl);


                }
            }

        }
        
    }   
    </script>

    <div style="margin:15px 15px 15px 15px;overflow-y:auto;max-height:600px">
        <table>
        <asp:PlaceHolder ID="pacnts" runat="server"></asp:PlaceHolder>
            </table>
    </div>





</asp:Content>

