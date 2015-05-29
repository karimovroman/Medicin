using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_service : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Name_serv
    {
        set
        {
            serv_name.Text = value +" ";
        }
    }
    public string About
    {
        set
        {
            about.Text = value;
        }
    }
    public string Cost
    {
        set
        {
            cost.Text = value;
        }
    }
    public string Id_serv
    {
        set
        {
            serv_id.Text = value;
        }
    }
    
    
    protected void record_Click(object sender, ImageClickEventArgs e)
    {
        HttpCookie cookie = new HttpCookie("service");
        cookie["servid"] = serv_id.Text;
        cookie["servname"] = serv_name.Text;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/regservices.aspx");
    }
}