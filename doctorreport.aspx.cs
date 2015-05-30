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

public partial class doctorreport : System.Web.UI.Page
{
    DBase.MSSQL mssql = new DBase.MSSQL();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<DBase.doctor> pats = mssql.GetAllDoctors();
        List<DBase.doctor> patlist = new List<DBase.doctor>();
            
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies["user"];
            int userid = Convert.ToInt32(cookie["iduser"]);
            int moid = mssql.GetRegistratorMO(userid);
            foreach (DBase.doctor p in pats)
               // if (Convert.ToInt32(p.Mo) == moid)
                {
                    doctorlist.Items.Add(new ListItem(p.Sur + " " + p.Name.Substring(0, 1) + "." + p.Mid.Substring(0, 1) + ".", Convert.ToString(p.Id)));
                    patlist.Add(p);
                }
        }
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
       
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specss = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();
        specss = mysql.SelectSpecDoctor();
        foreach (DBase.doctor p in pats)
            foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor s in specss)
             if (Convert.ToInt32(p.Id) == Convert.ToInt32(doctorlist.SelectedValue) && p.Idspec == s.id)
             {
                 special.Text = s.name;
                 dolgnost.Text = p.Dolj;
             }

        List<DBase.doctordesk> visits = mssql.GetAllDesk(Convert.ToInt32(doctorlist.SelectedValue));
        List<DBase.doctordesks> visitlist = mssql.GetAllDoctorDesk(Convert.ToInt32(doctorlist.SelectedValue));
        double[] yValues = { visitlist.Count, visits.Count, visits.Count - visitlist.Count};
        string[] xValues = { "Часы приема", "Количество записей", "Эффективность" };
        Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

        Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
        Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
        Chart1.Series["Default"].Points[2].Color = Color.LawnGreen;

        Chart1.Series["Default"].ChartType = SeriesChartType.Column;

        Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

        Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

        Chart1.Legends[0].Enabled = true;

        zapcount.Text = Convert.ToString(visitlist.Count);
        succount.Text = Convert.ToString(visits.Count);
        if (visitlist.Count == 0){
            Chart1.Visible = false;
            zapcount.Visible = false;
            succount.Visible = false;
            h1.Visible = false;
            h2.Visible = false;
        }
        else { 
            Chart1.Visible = true;
            zapcount.Visible = true;
            succount.Visible = true;
            h1.Visible = true;
            h2.Visible = true;
        }
        ////////////////
       

    }

}