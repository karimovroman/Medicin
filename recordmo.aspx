<%@ Page Title="Записаться на прием: Выбор медицинского учреждения" Language="C#" MasterPageFile="~/SitePatient.master" AutoEventWireup="true" CodeFile="recordmo.aspx.cs" Inherits="recordmo" %>
<%@ Reference Control="~/Templates/mo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script runat="server">
        void Page_Load(Object sender, EventArgs e)
        {
            DBase.MSSQL mssql = new DBase.MSSQL();
            List<DBase.mo> mos = mssql.GetMo();
            foreach (DBase.mo m in mos)
            {
                Templates_mo cntrl = (Templates_mo)LoadControl("Templates/mo.ascx");
                cntrl.Name_spec = m.Name;
                cntrl.Id_spec = Convert.ToString(m.Id);
                cpecialisti.Controls.Add(cntrl);
            }
        }
    </script>



    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <h1>Для записи выберите учреждение</h1>
            </td>
        </tr>

        <asp:PlaceHolder ID="cpecialisti" runat="server"></asp:PlaceHolder>
    </table>
</asp:Content>

