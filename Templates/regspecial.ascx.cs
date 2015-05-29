using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_regspecial : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void click(Object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies["medicin"];
        cookie["regspecid"] = spec_id.Text ; 
        cookie["regspecname"] = spec_name.Text;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/regrecorddoctor.aspx");
    }   

    public string Name_spec
    {
        set
        {
            spec_name.Text = value;
        }
    }
    public string Id_spec
    {
        set
        {
            spec_id.Text = value;
        }
    }
    
   
}