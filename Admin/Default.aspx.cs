using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute.MyResult res = new MySqlLib.MySqlData.MySqlExecute.MyResult();
        res = MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("SHOW VARIABLES LIKE \" % version % \";", "SERVER=91.202.254.179;DATABASE=medic;UID=root;PASSWORD=romviktori;");
        // Label2.Text = MySqlLib.MySqlData.MySqlExecute.CreateBD();

        if (res.HasError == false)
        {
            mysql.Text = Convert.ToString("MySql online");
            mysql.ForeColor = System.Drawing.Color.Black;
            // Label1.Text = res.ResultText;
        }
        if (res.HasError == true)
        {
            mysql.Text = Convert.ToString("MySql offline");
            mysql.ForeColor = System.Drawing.Color.Red;
        }


        DBase.MSSQL ms = new DBase.MSSQL();
        mssql.Text = ms.MSSQLStatus();
        mssql.ForeColor = System.Drawing.Color.Black;
    }
}