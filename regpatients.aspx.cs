using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regpatients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.strahovay> str = mysql.SelectStrah();
        foreach (MySqlLib.MySqlData.MySqlExecute.strahovay st in str)
        {
            strahkom.Items.Add(new ListItem(st.name, Convert.ToString(st.id)));
        }
    }
    protected void oms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (oms.SelectedValue == "Есть")
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
    protected void daterozden_DataBinding(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Convert.ToDateTime(daterozden.Text).ToShortDateString().Substring(6, 4)) > 2015)
            daterozden.Text = "2015" + daterozden.Text.Substring(4, 6);
    }
    protected void kogdavid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Convert.ToDateTime(kogdavid.Text).ToShortDateString().Substring(6, 4)) > 2015)
                kogdavid.Text = "2015" + kogdavid.Text.Substring(4, 6);
        }
        catch { }
    }
    protected void datevid_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Convert.ToDateTime(datevid.Text).ToShortDateString().Substring(6, 4)) > 2015)
                datevid.Text = "2015" + datevid.Text.Substring(4, 6);
        }
        catch { }
    }
}