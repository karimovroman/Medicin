using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();

        List<DBase.patient> pats = mssql.GetAllPatient();
        List<DBase.doctor> docs = mssql.GetAllDoctors();
        List<DBase.mo> mos = mssql.GetMo();

        List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> leks = mysql.SelectLekarstvo();

        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specs = mysql.SelectSpecDoctor();

        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> diags = mysql.SelectZabDiagnoz();



        patient.Text = Convert.ToString(pats.Count());
        doct.Text = Convert.ToString(docs.Count());
        mois.Text = Convert.ToString(mos.Count());
        lekrs.Text = Convert.ToString(leks.Count());
        specis.Text = Convert.ToString(specs.Count());
        diagnoz.Text = Convert.ToString(diags.Count());
        MySqlLib.MySqlData.MySqlExecute.MyResult res = new MySqlLib.MySqlData.MySqlExecute.MyResult();
        res = MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("SHOW VARIABLES LIKE \" % version % \";", "SERVER=91.202.254.179;DATABASE=medic;UID=root;PASSWORD=romviktori;");
        // Label2.Text = MySqlLib.MySqlData.MySqlExecute.CreateBD();

        if (res.HasError == false)
        {
            my.Text = Convert.ToString("MySql online");
            my.ForeColor = System.Drawing.Color.Black;
            // Label1.Text = res.ResultText;
        }
        if (res.HasError == true)
        {
            my.Text = Convert.ToString("MySql offline");
            my.ForeColor = System.Drawing.Color.Red;
        }


        DBase.MSSQL mss = new DBase.MSSQL();
        ms.Text = mss.MSSQLStatus();
        ms.ForeColor = System.Drawing.Color.Black;

    }
}