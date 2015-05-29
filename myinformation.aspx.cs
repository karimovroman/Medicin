using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myinformation : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
        }
    }
    protected void daterozden_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Convert.ToDateTime(daterozden.Text).ToShortDateString().Substring(6, 4)) > 2015)
            daterozden.Text ="2015"+ daterozden.Text.Substring(4,6);
        vozrast.Text = Convert.ToString(Convert.ToInt32(DateTime.Now.ToShortDateString().Substring(6, 4)) - Convert.ToInt32(Convert.ToDateTime(daterozden.Text).ToShortDateString().Substring(6, 4)));
        
        if (Convert.ToInt32( vozrast.Text) >=14)
        {

        }
        else
        {

        }
    }
    protected void kogdavid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Convert.ToDateTime(kogdavid.Text).ToShortDateString().Substring(6, 4)) > 2015)
                kogdavid.Text = "2015" + kogdavid.Text.Substring(4, 6);
        }
        catch { kogdavid.Text = "2015-01-01"; }
    }
    protected void datevid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Convert.ToDateTime(datevid.Text).ToShortDateString().Substring(6, 4)) > 2015)
                datevid.Text = "2015" + datevid.Text.Substring(4, 6);
        }
        catch { datevid.Text = "2015-01-01"; }
    }
    protected void oms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(oms.SelectedValue== "Есть")
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
}