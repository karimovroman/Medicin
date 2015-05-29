using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_services : System.Web.UI.UserControl
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
    public string Idst
    {
        set
        {
            idservtime.Text = value;
        }
    }
   
    
    protected void kvitanc_Click(object sender, EventArgs e)
    {
        HttpCookie cookie3 = new HttpCookie("kvitanc");
        cookie3["pacid"] = pacid.Text;
        cookie3["idvisit"] = idservtime.Text;
        cookie3.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie3);

        Response.Redirect("~/Docs/servkvitanc.aspx");

    }
    protected void dogovor_Click(object sender, EventArgs e)
    {
        HttpCookie cookie3 = new HttpCookie("dogovor");
        cookie3["pacid"] = pacid.Text;
        cookie3["idvisit"] = idservtime.Text;
        cookie3.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie3);

        Response.Redirect("~/Docs/servdogovor.aspx");
    }
    protected void yes_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.successervice> servsucs = mssql.GetServiceSuccess();
        foreach (DBase.successervice ss in servsucs)
        {
            if (ss.Idservtime == Convert.ToInt32(idservtime.Text))
                y = 1;
        }
        if (y == 0)
            mssql.InsertServiceSuccess(Convert.ToInt32(idservtime.Text), 1);
        
    }
    protected void no_Click(object sender, ImageClickEventArgs e)
    {
        int y = 0;
        DBase.MSSQL mssql = new DBase.MSSQL();
        List<DBase.successervice> servsucs = mssql.GetServiceSuccess();
        foreach (DBase.successervice ss in servsucs)
        {
            if (ss.Idservtime == Convert.ToInt32(idservtime.Text))
                y = 1;
        }
        if (y == 0)
            mssql.InsertServiceSuccess(Convert.ToInt32(idservtime.Text), 0);
        
    }
}