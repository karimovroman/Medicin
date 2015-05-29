﻿<%@ Page Title="Записаться на прием: Выбор доктора" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="regrecordpoint.aspx.cs" Inherits="Recordpoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        string time = "", datazap = "", patientid = "", specid = "", doctorid = "", nowtime = "", specname = "";
        HttpCookie cookie = Request.Cookies["medicin"];
        if (cookie != null)
        {
            time = (cookie["regrecordtime"]);
            specid = (cookie["regspecid"]);
            specname = (cookie["regspecname"]);
            doctorid = (cookie["regdoctorid"]);
            patientid = (cookie["regpatientid"]);
            datazap = (cookie["regdataz"]);
            nowtime = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();
        }
        else
        {
            Response.Redirect("recordspec.aspx");
        }

        DBase.MSSQL mssql = new DBase.MSSQL();
        DBase.password pass = new DBase.password();

        DBase.doctordesk desk = new DBase.doctordesk();

        List<DBase.doctor> alld = new DBase.MSSQL().GetAllDoctors();
        DBase.doctor doc = new DBase.doctor();
        List<DBase.mo> listmo = mssql.GetMo();

        List<DBase.patient> allp = new DBase.MSSQL().GetAllPatient();
        DBase.patient pat = new DBase.patient();
        iddesk.Text = DateTime.Now.ToShortDateString().Substring(0, 2) + DateTime.Now.ToShortDateString().Substring(3, 2) + DateTime.Now.ToShortDateString().Substring(6, 4) + pass.generate();

        foreach (DBase.doctor d in alld)
        {
            if (d.Id == Convert.ToInt32(doctorid))
            {
                doc = d;
            }
        }
        foreach (DBase.mo m in listmo)
            if (m.Id == 2)
            {
                mo.Text = m.Name;
                namemo.Text = m.Name + " . Телефон " + m.Phone;
                moid = Convert.ToString(m.Id);
            }
        foreach (DBase.patient p in allp)
        {
            if (p.PatientID == Convert.ToInt32(patientid))
            {
                pat = p;
            }
        }
        doct = doctorid;
        pacient = Convert.ToString(pat.PatientID);
        DBase.predstavitel patpred = new DBase.MSSQL().GetPatientPredstavitel(pat.PatientID);
        emailp = patpred.Phone2;

        desk.Data = datazap;
        data.Text = desk.Data;
        desk.DoctorID = doc.Id;
        doctor.Text = doc.Name + " " + doc.Mid + " " + doc.Sur;
        desk.Time = time;
        times.Text = time;
        desk.PacientID = pat.PatientID;
        cabin.Text = doc.Kabin;
        pac.Text = pat.Fam + " " + pat.Im + " " + pat.Otch + ", " + pat.Datr;

        spec.Text = specname;
    }   
    
</script>


    <script type="text/javascript">
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }</script>
    <div id="" class="printable">
    <asp:Label ID="zag" class="printable" runat="server" Font-Bold="true" Text="Запись к врачу пациента: "></asp:Label><br />
        <asp:Panel ID="pan" runat="server">
    <asp:Label ID="mo" class="printable" runat="server" Text="Название МО"></asp:Label>
    
    <table id="printable" style="width:500px;border-width:1px" class="printable">
        <tr>
            <td style="width:150px;text-align:left">
                Запись №:
            </td>
            <td >
                <asp:Label ID="iddesk" runat="server" Text="номер записи"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Учреждение:
            </td>
            <td >
                <asp:Label ID="namemo" runat="server" Text="название учреждения"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Дата:
            </td>
            <td >
                <asp:Label ID="data" runat="server" Text="дата посещения"></asp:Label>                <br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Время:
            </td>
            <td >
                <asp:Label ID="times" runat="server" Text="время посещения"></asp:Label><br />
            </td>
        </tr>
         <tr>
            <td style="width:150px;text-align:left">
                ФИО врача:
            </td>
            <td >
                <asp:Label ID="doctor" runat="server" Text="доктор"></asp:Label><br />
            </td>
        </tr>
        <tr>
        <td style="width:150px;text-align:left">
                Специальность:
            </td>
            <td >
                <asp:Label ID="spec" runat="server" Text="специальность врача"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Кабинет:
            </td>
            <td >
                <asp:Label ID="cabin" runat="server" Text="кабинет врача"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Данные пациента:
            </td>
            <td >
                <asp:Label ID="pac" runat="server" Text="ФИО и дата"></asp:Label><br />
            </td>
        </tr>
    </table> </div>
    <div style="text-align:right;width:400px;margin-right:60px" >
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Отправить на почту"/>
         <a href ="Docs/regrecordlist.aspx"><img src="images/print.png" alt="Печать" height="32" width="32" onclick="" class="no_print"> </a>
           <asp:Button runat="server" CssClass="mbg" Text="Записаться" OnClick="Unnamed_Click" />
    
    
    </div>
     </asp:Panel>
    <asp:Panel ID="panelka" runat="server" Visible="false">
        <asp:Label id="inform" runat="server"  Text="Пациент записан на прием. Нажмите выход для перехода на главную встраницу."></asp:Label>
        <div style="text-align:right;width:500px;margin-top:100px">
                
                <a href ="patient.aspx">Выход</a>
         </div>
    
    </asp:Panel>
</asp:Content>

