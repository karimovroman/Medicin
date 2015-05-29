using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class emk_doc : System.Web.UI.Page
{
    public string pacid = "";
    public string docid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
       

            HttpCookie cookie = Request.Cookies["patient"];
            if (cookie != null)
            {
                pacid = cookie["idpatient"];
            }
            else
                Response.Redirect("pacients.aspx");
            HttpCookie cookiee = Request.Cookies["user"];
            if (cookiee != null)
            {
                if (cookiee["typeuser"] == "doctor")
                    docid = cookiee["iduser"];
            }
            else
                Response.Redirect("pacients.aspx");
      
        List<DBase.emk> emks = mssql.GetEmk(Convert.ToInt32(pacid));
        emks.Reverse();
        if (emks.Count != 0)
        {

            DBase.emk emk = emks.First();

            //Заполняем поля данными
            grupa.Text = emk.Grupkrov;
            rezus.Text = emk.Rezus;
            rebenok.Text = emk.Kategreben;
            katyceta.Text = emk.Kategsocial;
            zdorgrupa.Text = emk.Grupzdorov;
            kyren.Text = emk.Kyrenie;
            alkog.Text = emk.Alcogol;
            narkom.Text = emk.Narkot;
            allerg.Text = emk.Alerg;
            neperen.Text = emk.Neperen;
            xarak.Text = emk.Haract;
            semanam.Text = emk.Anamnez;
            inval.Text = emk.Invalid;
            otkl.Text = emk.Otklon;
            psihmot.Text = emk.Psihomotor;
            intel.Text = emk.Intelect;

        }
       
    }
}