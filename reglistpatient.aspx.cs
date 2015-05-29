using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reglistpatient : System.Web.UI.Page
{
    DBase.MSSQL mssql = new DBase.MSSQL();
       
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //   
    //    List<DBase.patient> pats = new List<DBase.patient>();
    //    pats = mssql.GetAllPatient();

    //    foreach (DBase.patient p in pats)
    //    {
    //        if (p.PatientID == Convert.ToInt32(DropDownList1.SelectedValue))
    //        {
    //            DBase.patient pat = p;
    //            DBase.predstavitel prt = mssql.GetPatientPredstavitel(pat.PatientID);
    //            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
    //            List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
    //            foreach (MySqlLib.MySqlData.MySqlExecute.strahovay st in str)
    //            {
    //                strahkom.Items.Add(new ListItem(st.name, Convert.ToString(st.id)));
    //            }
    //            school.Text = pat.School;
    //            fam.Text = pat.Fam;
    //            name.Text = pat.Im;
    //            otch.Text = pat.Otch;
    //            snils.Text = pat.Snils;
    //            inn.Text = pat.Inn;
    //            daterozden.Text = pat.Datr;
    //            mesto.Text = pat.Mest;
    //            vozrast.Text = pat.Vozr;
    //            pol.Text = pat.Pol;
    //            doc.Text = pat.Dok;
    //            numoms.Text = pat.Noms;
    //            seroms.Text = pat.Soms;
    //            sempol.Text = pat.Sem;
    //            seriya.Text = pat.Sernom;
    //            kemvidan.Text = pat.Kemv;
    //            rassa.Text = pat.Rassa;
    //            rabota.Text = pat.Rabot;
    //            kogdavid.Text = pat.Datv;
    //            tipoms.SelectedValue = pat.Typpolis;
    //            hartrud.SelectedValue = pat.Trud;
    //            strahkom.SelectedValue = pat.Strax;
    //            (deti.Text) = Convert.ToString(pat.Det);
    //            dms.Text = pat.Dms;
    //            datevid.Text = pat.Datoms;
    //            obraz.Text = pat.Obraz;
    //            dolj.Text = pat.Dolg;
    //            oms.Text = pat.Oms;
    //            //Представитель пациента
    //            fio.Text = prt.Fio;
    //            rodstvo.Text = prt.Rodstvo;
    //            pdoc.Text = prt.Doc;
    //            psernum.Text = prt.Num;
    //            pkem.Text = prt.Vidan;
    //            pkogda.Text = prt.Kogda;
    //            padr.Text = prt.Address;
    //            pphone.Text = prt.Phone;
    //            pphone2.Text = prt.Phone2;
    //        }
    //    }
    //}
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
            DBase.patient pat = new DBase.patient();
            DBase.predstavitel prt = new DBase.predstavitel();
            pat = mssql.Getpatient(Convert.ToInt32(DropDownList1.SelectedValue));
            prt = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));
            //Пациент
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
            
            school.Text = pat.School;
            fam.Text = pat.Fam;
            name.Text = pat.Im;
            otch.Text = pat.Otch;
            snils.Text = pat.Snils;
            inn.Text = pat.Inn;
            daterozden.Text = pat.Datr;
            mesto.Text = pat.Mest;
            vozrast.Text = pat.Vozr;
            pol.Text = pat.Pol;
            doc.Text = pat.Dok;
            numoms.Text = pat.Noms;
            seroms.Text = pat.Soms;
            sempol.SelectedValue = pat.Sem;
            seriya.Text = pat.Sernom.Substring(0, 4);
            numbers.Text = pat.Sernom.Substring(4, 6);
            kemvidan.Text = pat.Kemv;
            rassa.Text = pat.Rassa;
            rabota.Text = pat.Rabot;
            kogdavid.Text = pat.Datv;
            tipoms.SelectedValue = pat.Typpolis;
            hartrud.SelectedValue = pat.Trud;
            strahkom.SelectedValue = pat.Strax;
            (deti.Text) = Convert.ToString(pat.Det);
            dms.SelectedValue = pat.Dms;
            datevid.Text = pat.Datoms;
            obraz.SelectedValue = pat.Obraz;
            dolj.Text = pat.Dolg;
            oms.Text = pat.Oms;
            mo.Text = Convert.ToString(pat.Mo);
            //Представитель пациента 
            int w = 0;
            if (prt.Fio != null)
            {
                for (int i = 0; i < prt.Fio.Length; i++)
                {
                    if (Convert.ToString(prt.Fio[i]) != " " && w == 0)
                        fiop.Text += prt.Fio[i];
                    else
                    {
                        w = 1;
                    }
                    if (Convert.ToString(prt.Fio[i]) != " " && w == 1)
                        imp.Text += prt.Fio[i];
                    else
                    {
                        w = 2;
                    }
                    if (Convert.ToString(prt.Fio[i]) != " " && w == 2)
                        otchp.Text += prt.Fio[i];
                    else
                    {
                        w = 1;
                    }
                }
            }

            rodstvo.SelectedValue = prt.Rodstvo;
            pdoc.Text = prt.Doc;
            if (prt.Num != null)
            {
                pser.Text = prt.Num.Substring(0, 4);
                pnum.Text = prt.Num.Substring(4, 6);
            }
            pkem.Text = prt.Vidan;
            pkogda.Text = prt.Kogda;
            padr.Text = prt.Address;

            sphone.Text = prt.Sphone;
            pphone.Text = prt.Phone;
            pphone2.Text = prt.Phone2;
            prtid.Text = Convert.ToString(prt.Id);
        
    }
    protected void oms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (oms.SelectedValue == "Есть")
        {
            oms1.Visible = true;
            oms2.Visible = true;
            oms3.Visible = true;
            oms4.Visible = true;
            oms5.Visible = true;
        }
        if (oms.SelectedValue == "Нет")
        {
            oms1.Visible = false;
            oms2.Visible = false;
            oms3.Visible = false;
            oms4.Visible = false;
            oms5.Visible = false;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DBase.patient pat = new DBase.patient();
        DBase.predstavitel prt = new DBase.predstavitel();
        pat = mssql.Getpatient(Convert.ToInt32(DropDownList1.SelectedValue));
        prt = mssql.GetPatientPredstavitel(Convert.ToInt32(DropDownList1.SelectedValue));
        //Пациент
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
        
        school.Text = pat.School;
        fam.Text = pat.Fam;
        name.Text = pat.Im;
        otch.Text = pat.Otch;
        snils.Text = pat.Snils;
        inn.Text = pat.Inn;
        daterozden.Text = pat.Datr;
        mesto.Text = pat.Mest;
        vozrast.Text = pat.Vozr;
        pol.Text = pat.Pol;
        doc.Text = pat.Dok;
        numoms.Text = pat.Noms;
        seroms.Text = pat.Soms;
        sempol.SelectedValue = pat.Sem;
        seriya.Text = pat.Sernom.Substring(0, 4);
        numbers.Text = pat.Sernom.Substring(4, 6);
        kemvidan.Text = pat.Kemv;
        rassa.Text = pat.Rassa;
        rabota.Text = pat.Rabot;
        kogdavid.Text = pat.Datv;
        tipoms.SelectedValue = pat.Typpolis;
        hartrud.SelectedValue = pat.Trud;
        strahkom.SelectedValue = pat.Strax;
        (deti.Text) = Convert.ToString(pat.Det);
        dms.SelectedValue = pat.Dms;
        datevid.Text = pat.Datoms;
        obraz.SelectedValue = pat.Obraz;
        dolj.Text = pat.Dolg;
        oms.Text = pat.Oms;
        mo.Text = Convert.ToString(pat.Mo);
        //Представитель пациента 
        int w = 0;
        if (prt.Fio != null)
        {
            for (int i = 0; i < prt.Fio.Length; i++)
            {
                if (Convert.ToString(prt.Fio[i]) != " " && w == 0)
                    fiop.Text += prt.Fio[i];
                else
                {
                    w = 1;
                }
                if (Convert.ToString(prt.Fio[i]) != " " && w == 1)
                    imp.Text += prt.Fio[i];
                else
                {
                    w = 2;
                }
                if (Convert.ToString(prt.Fio[i]) != " " && w == 2)
                    otchp.Text += prt.Fio[i];
                else
                {
                    w = 1;
                }
            }
        }

        rodstvo.SelectedValue = prt.Rodstvo;
        pdoc.Text = prt.Doc;
        if (prt.Num != null)
        {
            pser.Text = prt.Num.Substring(0, 4);
            pnum.Text = prt.Num.Substring(4, 6);
        }
        pkem.Text = prt.Vidan;
        pkogda.Text = prt.Kogda;
        padr.Text = prt.Address;

        sphone.Text = prt.Sphone;
        pphone.Text = prt.Phone;
        pphone2.Text = prt.Phone2;
        prtid.Text = Convert.ToString(prt.Id);
    }
}