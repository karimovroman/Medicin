using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class metrics : System.Web.UI.Page
{
    public string pacid = "";
    public string docid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpCookie cookie = Request.Cookies["patient"];
            if (cookie != null)
            {
                pacid = cookie["idpatient"];
            }
            else
                Response.Redirect("pacients.aspx");
            HttpCookie cookiee = Request.Cookies["user"];
            if (cookiee != null)
            {
                if (cookiee["typeuser"] == "doctor")
                    docid = cookiee["iduser"];
            }
            else
                Response.Redirect("pacients.aspx");
        }

    }
   
}