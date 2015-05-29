using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regrecordservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        string userid = "", username = "";
        HttpCookie cookie = Request.Cookies["user"];
        userid =(cookie["iduser"]);
        int moid = mssql.GetRegistratorMO(Convert.ToInt32(userid));
        List<DBase.service> serlists = mssql.GetServicesMo(moid);
        List<DBase.servicetime> servs = mssql.GetAllServicesTime();
        List<DBase.patient> pats = mssql.GetAllPatient();

        foreach (DBase.servicetime st in servs)
            foreach(DBase.service s in serlists)
                if (st.Service == s.Id && st.Data == DateTime.Now.ToShortDateString())
                {
                    Templates_services cntrl = (Templates_services)LoadControl("Templates/services.ascx");
                    cntrl.Time = st.Time;
                    cntrl.Idst = Convert.ToString(st.Id);

                    foreach (DBase.patient p in pats)
                        if (st.Idpac == p.PatientID)
                        { 
                            cntrl.Fio = p.Fam + " " + p.Im + " " + p.Otch + " записан на \"" + s.Name + "\"";
                            cntrl.Pid = Convert.ToString(p.PatientID);
                        }

                    zaplist.Controls.Add(cntrl);
                    zagol.Text = "Записи на оказание услуг:";
                }

        if (zaplist.Controls.Count < 1)
        {
            zagol.Text = "Нет записей на сегодня.";
            zagol.ForeColor = System.Drawing.Color.DarkRed;
        }

    }
}