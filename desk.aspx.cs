using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class desk : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        HttpCookie cookie = Request.Cookies["user"];
        if(cookie != null)
        {

        int userid = Convert.ToInt32(cookie["iduser"]);
        int moid = mssql.GetRegistratorMO(userid);
        List<DBase.doctordesk> desklist = mssql.GetAlDesk();
        List<DBase.doctor> docts = mssql.GetAllDoctors();
        List<DBase.patient> pats = mssql.GetAllPatient();
        List<DBase.successdesk> desks = mssql.GetAllDeskSuccess();
        foreach(DBase.successdesk d in desks)
            if(d.Success == 2)
            {
                Templates_zapros cntrl = new Templates_zapros();
                cntrl = (Templates_zapros)LoadControl("Templates/zapros.ascx");
                foreach(DBase.doctordesk dd in desklist)
                    if(d.Idvisits == dd.Id)
                    {
                         cntrl.Time = dd.Time;
                         cntrl.Idvisit = Convert.ToString(dd.Id);
                         cntrl.Id = Convert.ToString(d.Id);
                         string pfio = "", email = "";
                        foreach (DBase.patient pat in pats)
                            if (dd.PacientID == pat.PatientID)
                            {
                                pfio =   pat.Fam + " " + pat.Im.Substring(0,1) + "." + pat.Otch.Substring(0,1);
                                DBase.predstavitel pr = mssql.GetPatientPredstavitel(pat.PatientID);
                                email = pr.Phone2;
                            }
                        foreach (DBase.doctor doc in docts)
                            if (dd.DoctorID == doc.Id)
                        {
                                
                            cntrl.Fio = pfio + " к " + doc.Sur + " " + doc.Name.Substring(0, 1) + "." + doc.Mid.Substring(0, 1);
                        }
                        cntrl.Pid = email;
                    }

                
               
                zapros.Controls.Add(cntrl);
                zagol.Text = "Запросы на запись:";
            }




        }
    }
}