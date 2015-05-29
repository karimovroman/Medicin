using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            HttpCookie cookie = Request.Cookies["user"];
            cookie["iduser"] = "Anonymous";
            cookie["fiouser"] = "Anonymous";
            cookie["typeuser"] = "Anonymous";

            cookie.Expires = new DateTime(100);
            Response.Cookies.Add(cookie);
            
        }
        finally
        {
            Response.Redirect("Default.aspx");
        }


    }
}