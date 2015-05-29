using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Web.UI.DataVisualization.Charting;

public partial class patientreport : System.Web.UI.Page
{
    DBase.MSSQL mssql = new DBase.MSSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        { 
        HttpCookie cookie = Request.Cookies["user"];
        int userid = Convert.ToInt32(cookie["iduser"]);
        int moid = mssql.GetRegistratorMO(userid);
        List<DBase.patient> pats = mssql.GetAllPatient();
        List<DBase.patient> patlist = new List<DBase.patient>();
        foreach (DBase.patient p in pats)
            if (p.Mo == moid)
            { 
                patientlist.Items.Add(new ListItem(p.Fam + " " + p.Im.Substring(0, 1) + "." + p.Otch.Substring(0, 1) + ".", Convert.ToString(p.PatientID)));
                patlist.Add(p);
            }
        }
        List<DBase.doctordesk> visits = mssql.GetAlDesk();
        List<DBase.doctordesk> visitlist = new List<DBase.doctordesk>();
        foreach(DBase.doctordesk dd in visits)
            if(dd.PacientID == Convert.ToInt32(patientlist.SelectedValue))
            {
                visitlist.Add(dd);
            }

        List<DBase.successdesk> desksucs = mssql.GetAllDeskSuccess();
        List<DBase.successdesk> desksuclist = new List<DBase.successdesk>();
        List<DBase.successdesk> desksuclist2 = new List<DBase.successdesk>();
        foreach (DBase.successdesk ds in desksucs) 
            foreach(DBase.doctordesk dd in visits){
                if(dd.Id == ds.Idvisits && ds.Success == 1)
                    {
                        desksuclist.Add(ds);
                    }
                    if (dd.Id == ds.Idvisits && ds.Success == 0)
                    {
                        desksuclist2.Add(ds);
                    }
            }

        List<DBase.servicetime> servlist = mssql.GetAllServicesTime();
        List<DBase.servicetime> servlists = new List<DBase.servicetime>();
       
        foreach (DBase.servicetime dd in servlist)
            if (dd.Idpac == Convert.ToInt32(patientlist.SelectedValue))
            {
                servlists.Add(dd);
            }

        List<DBase.successervice> servsucs = mssql.GetAllServSuccess();
        List<DBase.successervice> servsuclist = new List<DBase.successervice>();
        List<DBase.successervice> servsuclist2 = new List<DBase.successervice>();
        foreach (DBase.successervice ds in servsucs)
            foreach (DBase.servicetime dd in servlists)
            {
                if (dd.Id == ds.Idservtime && ds.Success == 1)
                {
                    servsuclist.Add(ds);
                }
                if (dd.Id == ds.Idservtime && ds.Success == 0)
                {
                    servsuclist2.Add(ds);
                }
            }


        zapcount.Text = Convert.ToString(visitlist.Count);
        succount.Text = Convert.ToString(desksuclist.Count);

        servsuccount.Text = Convert.ToString(servsuclist.Count);
        servcount.Text = Convert.ToString(servlists.Count);
        if (servlists.Count == 0)
            Chart2.Visible = false;
        else
            Chart2.Visible = true;
        if (visitlist.Count == 0)
            Chart1.Visible = false;
        else
            Chart1.Visible = true;

        double[] yValues = { visitlist.Count, desksuclist.Count, desksuclist2.Count };
        string[] xValues = { "Записи на прием" , "Пришел", "Отсутствовал" };
        Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
        Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
        Chart1.Series["Default"].Points[2].Color = Color.LawnGreen;

        Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

        Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

        Chart1.Legends[0].Enabled = true;

        double[] yValues2 = { servlists.Count, servsuclist.Count, servsuclist2.Count };
        string[] xValues2 = { "Записи на прием", "Пришел", "Отсутствовал" };
        Chart2.Series["Default"].Points.DataBindXY(xValues2, yValues2);

        Chart2.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
        Chart2.Series["Default"].Points[1].Color = Color.PaleGreen;
        Chart2.Series["Default"].Points[2].Color = Color.LawnGreen;

        Chart2.Series["Default"].ChartType = SeriesChartType.Pie;

        Chart2.Series["Default"]["PieLabelStyle"] = "Disabled";

        Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

        Chart2.Legends[0].Enabled = true;

    }

        
}