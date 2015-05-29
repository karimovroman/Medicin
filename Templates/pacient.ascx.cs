using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_pac : System.Web.UI.UserControl
{
    public string Name_spec
    {
        set
        {
            FIO.Text = value;
        }
    }
    public string Id_spec
    {
        set
        {
            Id.Text = value;
        }
    }
    
    //protected void Dogovor_Click(object sender, ImageClickEventArgs e)
    //{
    //    HttpCookie cookie = new HttpCookie("Order");
    //    cookie.Expires = DateTime.Now.AddHours(1);
    //    cookie["order"] = orderid.Text;
    //    Response.Cookies.Add(cookie);
    //    Response.Redirect("docs/dogovor_temp.aspx");
    //}
    //protected void Blist_Click(object sender, ImageClickEventArgs e)
    //{
    //    HttpCookie cookie = new HttpCookie("Order");
    //    cookie.Expires = DateTime.Now.AddHours(1);
    //    cookie["order"] = orderid.Text;
    //    Response.Cookies.Add(cookie);
    //    Response.Redirect("docs/listb_temp.aspx");
    //}
    //protected void Bill_Click(object sender, ImageClickEventArgs e)
    //{
    //    HttpCookie cookie = new HttpCookie("Order");
    //    cookie.Expires = DateTime.Now.AddHours(1);
    //    cookie["order"] = orderid.Text;
    //    Response.Cookies.Add(cookie);
    //    Response.Redirect("docs/schet_temp.aspx");
    //}



    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void emks_Click(object sender, EventArgs e)
    {
        
        HttpCookie cookie = new HttpCookie("patient");
        cookie["idpatient"] = Id.Text;
        cookie.Expires = DateTime.Now.AddMinutes(3); ;
        Response.Cookies.Add(cookie);
        Response.Redirect("emk.aspx");
    } 
    
}