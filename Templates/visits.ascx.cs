using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_visits : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Time
    {
        set
        {
            time.Text = value;
        }
    }
    public string Fio
    {
        set
        {
            fio.Text = value;
        }
    }
    public string Id
    {
        set
        {
            id.Text = value;
        }
    }
    public string Pid
    {
        set
        {
            pacid.Text = value;
        }
    }
    public string Idvisit
    {
        set
        {
            idvisit.Text = value;
        }
    }
   
    protected void rec_Click(object sender, EventArgs e)
    {
        HttpCookie cookie3 = new HttpCookie("patient");
        cookie3["idpatient"] = pacid.Text;
        cookie3.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie3);      
        HttpCookie cookie = new HttpCookie("doctordesk");
        cookie["id"] = id.Text;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/visits.aspx");
    }
    protected void yes_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.successvisit> servsucs = mssql.GetVisitsSuccess();
        foreach (DBase.successvisit ss in servsucs)
        {
            if (ss.Idvisits == Convert.ToInt32(idvisit.Text))
                y = 1;
        }
        if (y == 0)
            mssql.InsertVisitSuccess(Convert.ToInt32(idvisit.Text), 1);

    }
    protected void no_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
         List<DBase.successvisit> servsucs = mssql.GetVisitsSuccess();
        foreach (DBase.successvisit ss in servsucs)
        {
            if (ss.Idvisits == Convert.ToInt32(idvisit.Text))
                y = 1;
        }
        if (y == 0)
            mssql.InsertVisitSuccess(Convert.ToInt32(idvisit.Text), 0);

    }
}