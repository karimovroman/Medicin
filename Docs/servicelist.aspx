<%@ Page Language="C#" AutoEventWireup="true" CodeFile="servicelist.aspx.cs" Inherits="Docs_servicelist" %>
<script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        string time = "", datazap = "",patientid="",nowtime = "" , servid = "", name= "" , iduser = "";
        HttpCookie cookie2= Request.Cookies["service"];
        HttpCookie cookie3 = Request.Cookies["servicetime"];
        HttpCookie cookie4 = Request.Cookies["user"];
        HttpCookie cookie = Request.Cookies["medicin"];
        if (cookie3 != null && cookie2 != null)
        {
            time = (cookie3["regservtime"]);
            patientid = (cookie["regpatientid"]);
            datazap = (cookie3["regservdata"]);
            nowtime = DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.Date.ToShortTimeString();
            name = (cookie2["servname"]);
            servid = (cookie2["servid"]);
            iduser = "1";//(cookie4["iduser"]);
        }
        else
        {
            Response.Redirect("services.aspx");
        }
        
        DBase.MSSQL mssql = new DBase.MSSQL();
        DBase.password pass = new DBase.password();
        
        List<DBase.service> listserv = mssql.GetServices();
        List<DBase.mo> listmo = mssql.GetMo();
        List<DBase.patient> listpatient = mssql.GetAllPatient();


         DBase.service servs = new DBase.service();
        iddesk.Text = DateTime.Now.ToShortDateString().Substring(0, 2) + DateTime.Now.ToShortDateString().Substring(3, 2) + DateTime.Now.ToShortDateString().Substring(6, 4) + pass.generate();
        foreach(DBase.service s in listserv)
            if(s.Id == Convert.ToInt32(servid))
            {
                servabout.Text = s.About;
                cost.Text = s.Cost;
                servname.Text = s.Name;
                servs = s;
                serviceid =Convert.ToString(s.Id);
            }
        foreach (DBase.mo m in listmo)
            if (m.Id == 2)
            {
                mo.Text = m.Name;
                namemo.Text = m.Name + " . Телефон " + m.Phone;
            }
        foreach (DBase.patient p in listpatient)
            if (p.PatientID == Convert.ToInt32(iduser))
            {
                pacient = Convert.ToString(p.PatientID);

                DBase.predstavitel pred = mssql.GetPatientPredstavitel(p.PatientID);
                emailp = pred.Phone2;
                pac.Text = p.Fam + " " + p.Im + " " + p.Otch + " . Дата рождения " + p.Datr;
            }

        data.Text = datazap;
        times.Text = time;
        
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
            <a href="../servicepoint.aspx">Закрыть</a>
        </div>
     <div id="" class="printable" style="text-align:center;width:500px" >
         <asp:Image ID="yes" ImageUrl="~/images/yes.png" runat="server" />
    <asp:Label ID="zag" class="printable" runat="server" Font-Bold="true" Text="Вы записались на прием"></asp:Label><br />
    <asp:Label ID="mo" class="printable" runat="server" Text="Название МО"></asp:Label>
    
    <table id="printable" style="width:500px;border-width:1px;text-align:left" class="printable">
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
                Название:
            </td>
            <td >
                <asp:Label ID="servname" runat="server" Text="услуга"></asp:Label><br />
            </td>
        </tr>
        <tr>
        <td style="width:150px;text-align:left">
                Описание:
            </td>
            <td >
                <asp:Label ID="servabout" runat="server" Text=""></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td style="width:150px;text-align:left">
                Стоимость:
            </td>
            <td >
                <asp:Label ID="cost" runat="server" Text="стоимость"></asp:Label><br />
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
    </table> </div></div>
    </form>
</body>
</html>
