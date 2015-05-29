using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_special : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void click(Object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies["medicin"];
        cookie["specid"] = spec_id.Text ; 
        cookie["specname"] = spec_name.Text;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/recorddoctor.aspx");
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



    
}