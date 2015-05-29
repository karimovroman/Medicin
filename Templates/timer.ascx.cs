using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_tt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string Times
    {
        set
        {
            times.Text = value;
        }
    }
    public string Month
    {
        set
        {
            month.Text = value;
        }
    }
    public string Data
    {
        set
        {
            datazap.Text = value;
        }
    }

   protected void click(Object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("servicetime");
        cookie["regservtime"] = times.Text; ;
        cookie["regservdata"] = datazap.Text;
        Response.Cookies.Add(cookie);
        Response.Redirect("~/servicepoint.aspx");
    }


   protected void now_Click(object sender, EventArgs e)
   {
       Response.Write("sdafad");
   }
}