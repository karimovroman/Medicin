using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void shower(object sender, EventArgs e)
    {
        if(price.Visible == false)
        { 
            price.Visible = true;
            show.Text = "Закрыть";
        }
        else
        {
            price.Visible = false;
            show.Text = "Показать прайс-лист";
            ;
       }
    }
}