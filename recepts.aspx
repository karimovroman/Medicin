<%@ Page Title="Рецепты" Language="C#" MasterPageFile="~/SiteDoctor.master" AutoEventWireup="true" CodeFile="recepts.aspx.cs" Inherits="recepts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <script runat="server">
   
    protected void SaveMyInformation(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        DBase.recept recept = new DBase.recept();
        recept.Id = 0;
        recept.Idp = Convert.ToInt32(pacsid.Text);
        recept.Idv = Convert.ToInt32(docsid.Text);
        recept.Data = DateTime.Now.ToShortDateString();
        recept.Idl = Convert.ToInt32(lekars.SelectedValue);
        recept.Kolvodoz = koldoz.Text;
        recept.Kratnost = krpriem.Text;
        recept.Forma = formavip.Text;

        recept.Doza = dozalek.Text;
        recept.Number = seria.Text + " " + nomer.Text;
        if (profilakt.Checked == true)
            recept.Profilakt = "Да";
        else
            recept.Profilakt = "Нет";
        List<DBase.patient> patlist = mssql.GetAllPatient();
        List<DBase.doctor> doclist = mssql.GetAllDoctors();
        
        foreach(DBase.patient p in patlist)
        {
            if(p.PatientID == Convert.ToInt32(pacsid.Text))
            {
                DBase.predstavitel pr = mssql.GetPatientPredstavitel(p.PatientID);
                fio.Text = p.Fam + " " + p.Im + " " + p.Otch;
                vozr.Text = Convert.ToString(Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(p.Datr.Substring(6, 4)));
                addr.Text = pr.Address;
            }
        }
        foreach (DBase.doctor p in doclist)
        {
            if (p.Id == Convert.ToInt32(docsid.Text))
            {
                vrach.Text = p.Sur + " " + p.Name + " " + p.Mid;
            }
        }
        recept.Regnom = nomers.Text;
        recept.Serial = serial.Text;
        mssql.InsertRecept(recept);
        inform.Visible = false;
        rec.Visible = true;
        
        nomer.Text = recept.Regnom;
        seria.Text = recept.Serial;
        den.Text = recept.Data.Substring(0, 2);
        month.Text = " "+ recept.Data.Substring(3,2)+" ";
        god.Text = recept.Data.Substring(6);
        
        
    }
    protected void lekars_SelectedIndexChanged(object sender, EventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> str = mysql.SelectLekarstvo();
        string i = lekars.SelectedValue;
        MySqlLib.MySqlData.MySqlExecute.lekarstvo lek = new MySqlLib.MySqlData.MySqlExecute.lekarstvo();
        if (str.Count > 0)
        {
            foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo l in str)
            {

                if (l.id == Convert.ToInt32(i))
                {
                    lek = l;
                }
                
            }

            formavip.Text = str.First().type;
            dozalek.Text = str.First().doza;


        }
            
        formavip.Text = lek.type;
        dozalek.Text = lek.doza;
    }
    </script>
    <div runat="server" id="inform" visible="true">
        <asp:Label ID="pacsid" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="docsid" runat="server" Visible="false"></asp:Label>
    <table runat="server"  >
            <tr >
                <td colspan="2" style="text-align:center">
                    Заполните поля рецепта:
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Номер и серия:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px"  id="nomers" runat="server" ></asp:TextBox>
                    <asp:TextBox  width="200px"  id="serial" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Лекарство:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID ="lekars" AutoPostBack="true" OnSelectedIndexChanged="lekars_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Форма выпуска:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px"  id="formavip" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Доза:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px"  id="dozalek" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Кратность приема:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px"  id="krpriem" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Количество доз:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox  width="200px"  id="koldoz" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Профилактика:"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox    id="profilakt" runat="server" ></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right">
                    <br /><asp:Button ID="save" runat="server" OnClick="SaveMyInformation" CssClass="logo" Text="Сохранить результаты" />
                </td>
            </tr>
        </table>
        </div>
    <div id="rec" runat="server">
    <table>
         <tr>
            <td colspan="2" style="text-align:right;font-size:smaller">
                Приложение
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;font-style:oblique">
                Рецептурный бланк
            </td>
        </tr>
        <tr>
            <td style="width:300px;margin-right:20px">
                Министерство здравоохранения и социального развития Российской Федерации<br />
                <asp:Label ID ="motext" Text="Название учреждения" runat="server"></asp:Label>
            </td>
            <td style="width:300px;margin-right:20px">
                Код формы по ОКУД 3108805<br />
                Медицинская документация<br />
                Форма № 148-1/у-88 <br />
                Утверждена приказом Министерства здравоохранения и социального развития Российской Федерации от 12 февраля 2007 г. № 110
            </td>
        </tr>
        <tr style="border-top:solid;border-top-width:1px">
            <td style="width:300px;margin-right:20px">
            Рецепт
            </td>
            <td style="width:300px;margin-right:20px">
            Серия: <asp:Label ID="seria" runat="server"></asp:Label>№:<asp:Label ID="nomer" runat="server"></asp:Label><br />
            "<asp:Label ID="den" runat="server"></asp:Label>"<asp:Label ID="month" runat="server"></asp:Label><asp:Label ID="god" runat="server"></asp:Label>г. <br />
            <div style="font-size:x-small">(дата выписки рецепта)</div>
            </td>
        </tr>
        <tr >
            <td colspan="2" style="border-bottom:thick">
                Ф.И.О. больного <asp:Label ID="fio" runat="server"></asp:Label><br />
                Возраст <asp:Label ID="vozr" runat="server"></asp:Label><br />
                Адрес или № медицинской карты амбулаторного больного <asp:Label ID="addr" runat="server"></asp:Label><br />
                Ф.И.О. врача <asp:Label ID="vrach" runat="server"></asp:Label><br />
                Руб. Коп. Rp<br />
                . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .<br />
                . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . <br />
                . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . <br />
                <br />
                 </td>
        </tr>
         <tr >
            <td colspan="2" style="border-top:solid;border-top-width:1px">
                Подпись и личная печать врача.
                <br />
                <br />
                Рецепт действителен в течении 10 дней <u>1 месяца</u> (нужное зачеркнуть)
             </td>
        </tr>
    </table>
    </div>
</asp:Content>

