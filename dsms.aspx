<%@ Page Title="Сообщения" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="dsms.aspx.cs" Inherits="dsms" %>

<%@ Reference Control="~/Templates/smsmailt.ascx" %>
<%@ Reference Control="~/Templates/smsmailo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
       if(!IsPostBack)
       { 
        List<DBase.patient> alld = new DBase.MSSQL().GetAllPatient();
        foreach(DBase.patient  d in alld)
        {
            addres.Items.Add(new ListItem(d.Fam+" "+d.Im + " " + d.Otch, Convert.ToString(d.PatientID)));
        }
        List<DBase.sms> allsms = new DBase.MSSQL().GetAllSMS();
        foreach (DBase.sms j in allsms)
            {
                if(j.Otpac == pacid && j.Dodoc == Convert.ToInt32(addres.SelectedValue))
                {
                    Templates_smsmailt cntrl = (Templates_smsmailt)LoadControl("Templates/smsmailt.ascx");
                    cntrl.Mess = j.Data;
                    cntrl.Time = j.Time;
                    place.Controls.Add(cntrl);
                }
                if (j.Dopac == pacid && j.Otdoc == Convert.ToInt32(addres.SelectedValue))                {
                    Templates_smsmailo cntrl = (Templates_smsmailo)LoadControl("Templates/smsmailo.ascx");
                    cntrl.Mess = j.Data;
                    cntrl.Time = j.Time;
                    
                    place.Controls.Add(cntrl);
                }
            }
       } 
    }
    protected void addres_SelectedIndexChanged(object sender, EventArgs e)
    {
        place.Controls.Clear();
        
        List<DBase.sms> allsms = new DBase.MSSQL().GetAllSMS();
        foreach (DBase.sms j in allsms)
        {
            if (j.Otpac == pacid && j.Dodoc == Convert.ToInt32(addres.SelectedValue))
            {
                Templates_smsmailt cntrl = (Templates_smsmailt)LoadControl("Templates/smsmailt.ascx");
                cntrl.Mess = j.Data;
                cntrl.Time = j.Time;
                place.Controls.Add(cntrl);
            }
            if (j.Dopac == pacid && j.Otdoc == Convert.ToInt32(addres.SelectedValue))
            {
                Templates_smsmailo cntrl = (Templates_smsmailo)LoadControl("Templates/smsmailo.ascx");
                cntrl.Mess = j.Data;
                cntrl.Time = j.Time;

                place.Controls.Add(cntrl);
            }
        }
    }
    void Send(Object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        int r = mssql.SendSMS(msg.Text, 1, 0, 0, Convert.ToInt32(addres.SelectedValue), Convert.ToString(DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year));
        if (r!=0){
            msg.Text = "";
        }
        place.Controls.Clear();
        List<DBase.sms> allsms = new DBase.MSSQL().GetAllSMS();
        foreach (DBase.sms j in allsms)
        {
            if (j.Otpac == pacid && j.Dodoc == Convert.ToInt32(addres.SelectedValue))
            {
                Templates_smsmailt cntrl = (Templates_smsmailt)LoadControl("Templates/smsmailt.ascx");
                cntrl.Mess = j.Data;
                cntrl.Time = j.Time;
                place.Controls.Add(cntrl);
            }
            if (j.Dopac == pacid && j.Otdoc == Convert.ToInt32(addres.SelectedValue))
            {
                Templates_smsmailo cntrl = (Templates_smsmailo)LoadControl("Templates/smsmailo.ascx");
                cntrl.Mess = j.Data;
                cntrl.Time = j.Time;

                place.Controls.Add(cntrl);
            }
        }
    }
</script>
    <table >
        <tr>
            <td style="width:300px">
                <table
                    <tr style="text-align:center">
                        Адресаты:
                    </tr>
                    <tr style="text-align:left">
                        <asp:DropDownList ID="addres" AutoPostBack="true" OnSelectedIndexChanged="addres_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </tr>
                </table>
            </td>
            </tr>
        <tr>
            <td style="width:100%">
                <div style="margin:20px; overflow-y:auto; height:400px; width:450px;border:dotted">
                    <!-- Сюда выводим сообщения -->
                    <asp:PlaceHolder ID="place" runat="server" >

                    </asp:PlaceHolder>
                </div>
            </td>
        </tr>
        <tr><td>
             <div style="margin:20px; height:60px">
                    <!-- Сюда вводим сообщения -->
                   <asp:TextBox ID="msg" TextMode="MultiLine" runat="server" Height="60px" Width="360px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="send" ImageUrl="~/images/email.png" Height="50px" ToolTip="Отправить сообщение"  runat="server" OnClick="Send" />
             </div>
            </td>
       </tr>
    </table>

</asp:Content>

