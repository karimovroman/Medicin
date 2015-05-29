using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_regtime : System.Web.UI.UserControl
{
    public string datazap = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void click(Object sender, EventArgs e)
    {

        HttpCookie cookie = Request.Cookies["medicin"];
        cookie["regrecordtime"] = times.Text; ; //member.Fio;
        cookie["regdataz"] = datazap;
        cookie.Expires = DateTime.Now.AddHours(1);
        Response.Cookies.Add(cookie);
        Response.Redirect("~/regrecordpoint.aspx");
    }
    
    public string Times
    {
        set
        {
            times.Text = value;
        }
    }
    public string Data
    {
        set
        {
             datazap = value;
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