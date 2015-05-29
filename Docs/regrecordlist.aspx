   <%@ Page Language="C#" AutoEventWireup="true" CodeFile="regrecordlist.aspx.cs" Inherits="Docs_recordlist" %>
<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        string time = "", datazap = "",patientid="", specid = "", doctorid = "", nowtime = "" , specname = "" ;
        HttpCookie cookie = Request.Cookies["medicin"];
        if (cookie != null)
        {
            time = (cookie["regrecordtime"]);
            specid = (cookie["regspecid"]);
            specname = (cookie["regspecname"]);
            doctorid = (cookie["regdoctorid"]);
            patientid = "9";//(cookie["patientid"]);
            datazap = (cookie["regdataz"]);
            nowtime = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();
        }
        else
        {
            Response.Redirect("regrecordspec.aspx");
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


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Печать талона записи на прием</title>
    <style type="text/css">
        .center
{
    display: inline-block;
    =display: inline;
    =zoom: 1;
    position: relative;
    width: 50%;
    height: 50%;
    background: ;
    vertical-align: middle;
}
 
#wrapper
{
    position: fixed;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    text-align: center;
}
#wrapper:after
{
    display: inline-block;
    =display: inline;
    =zoom: 1;
    height: 100%;
    width: 0;
    vertical-align: middle;
    content: '';
}

@media print {
 
.noprint {
display: none;
}
 
}
    </style>
    
</head>
<body>
    <div id="wrapper">
    <form id="form1" runat="server" class="center">
        <div style="text-align:right;width:500px" class="noprint">
            <a href="../regrecordpoint.aspx">Закрыть</a>
        </div>
     <div id="" class="printable" style="text-align:center;width:500px" >
         <asp:Image ID="yes" ImageUrl="~/images/yes.png" runat="server" />
    <asp:Label ID="zag" class="printable" runat="server" Font-Bold="true" Text="Вы записались на прием"></asp:Label><br />
   <asp:Label ID="mo" runat="server" Text="Название МО"></asp:Label>
    
    <table style="width:500px;border-width:1px;text-align:left">
        <tr>
            <td style="width:150px;text-align:left">
                Запись №:
            </td>
            <td >
                <asp:Label ID="iddesk" runat="server" Text="номер записи"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Учреждение:
            </td>
            <td >
                <asp:Label ID="namemo" runat="server" Text="название учреждения"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Дата:
            </td>
            <td >
                <asp:Label ID="data" runat="server" Text="дата посещения"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Время:
            </td>
            <td >
                <asp:Label ID="times" runat="server" Text="время посещения"></asp:Label>
            </td>
        </tr>
         <tr>
            <td style="width:150px;text-align:left">
                ФИО врача:
            </td>
            <td >
                <asp:Label ID="doctor" runat="server" Text="доктор"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="width:150px;text-align:left">
                Специальность:
            </td>
            <td >
                <asp:Label ID="spec" runat="server" Text="специальность врача"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Кабинет:
            </td>
            <td >
                <asp:Label ID="cabin" runat="server" Text="кабинет врача"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Данные пациента:
            </td>
            <td >
                <asp:Label ID="pac" runat="server" Text="ФИО и дата"></asp:Label>
            </td>
        </tr>
    </table>  </div></div>
    </form>
</body>
</html>
