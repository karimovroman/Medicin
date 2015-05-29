using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visitslist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();   
        string userid = "", username = "";
        HttpCookie cookie = Request.Cookies["user"];
        if (cookie != null)
        {
            string type = (cookie["typeuser"]);
            if (type == "doctor")
            {
                userid = cookie["iduser"];
                username = cookie["fiouser"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        else
        {
            Response.Redirect("logout.aspx");
        }

        List<DBase.doctordesk> desks = mssql.GetAllDesk(Convert.ToInt32(userid));
        List<DBase.patient> pats = mssql.GetAllPatient();

        foreach( DBase.doctordesk dd in desks )
            if (dd.Data == DateTime.Now.ToShortDateString())
                {
                    Templates_visits cntrl = (Templates_visits)LoadControl("Templates/visits.ascx");
                    cntrl.Time = dd.Time;
                    cntrl.Idvisit = Convert.ToString(dd.Id);
                    cntrl.Pid = Convert.ToString(dd.PacientID);
                    cntrl.Id = Convert.ToString(dd.Id);
                    foreach (DBase.patient p in pats)
                        if (dd.PacientID == p.PatientID)
                            cntrl.Fio = p.Fam + " " + p.Im + " " + p.Otch;
                    zaplist.Controls.Add(cntrl);
                    zagol.Text = "Записи на прием:";
                }

        if(zaplist.Controls.Count < 1)
        {
            zagol.Text = "Нет записей на сегодня.";
            zagol.ForeColor = System.Drawing.Color.DarkRed;
        }

    }
}