<%@ Page Title="Регистратура: отчеты" Language="C#" MasterPageFile="~/SiteRegistr.master" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style runat="server" type="text/css">
    .blok {
position:relative;
width:50%;
padding:1em;
margin:5px 10px 5px;
background:#fff;
-webkit-box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
-moz-box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
box-shadow:0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
-webkit-box-shadow: 0 15px 10px -10px rgba(0, 0, 0, 0.5), 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
-moz-box-shadow: 0 15px 10px -10px rgba(0, 0, 0, 0.5), 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
box-shadow: 0 15px 10px -10px rgba(0, 0, 0, 0.5), 0 1px 4px rgba(0, 0, 0, 0.3), 0 0 40px rgba(0, 0, 0, 0.1) inset;
}

.blok:before,
.blok:after {
content:"";
position:absolute;
z-index:-2;
}

.blok p {
font-size:16px;
font-weight:bold;
}
</style>

    <table style="width:500px">
        <tr>
            <td>
                <a href="patientreport.aspx">
                    <div class="blok">
                        Отчеты по пациентам
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="doctorreport.aspx">
                    <div class="blok">
                        Отчеты по врачам
                    </div>
                </a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="moreport.aspx">
                    <div class="blok">
                        Отчеты по медицинским учреждениям
                    </div>
                </a>
            </td>
        </tr>
    </table>
</asp:Content>

