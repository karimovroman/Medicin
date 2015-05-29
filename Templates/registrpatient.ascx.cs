using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_registrpatient : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void click(Object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("medicin");
        cookie["regpatientid"] = spec_id.Text; //member.Fio;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
       Response.Redirect("~/regrecordspec.aspx");
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