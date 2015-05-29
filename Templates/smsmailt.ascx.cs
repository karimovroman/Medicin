using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templates_smsmailt : System.Web.UI.UserControl
{

    public string Mess
    {
        set
        {
            message.Text = value;
        }
    }
    public string Time
    {
        set
        {
            time.Text = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
}