using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MySqlLib.MySqlData.MySqlExecute.MyResult res = new MySqlLib.MySqlData.MySqlExecute.MyResult();
        res = MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("SHOW VARIABLES LIKE \" % version % \";", "SERVER=91.202.254.179;DATABASE=medic;UID=root;PASSWORD=romviktori;");
       // Label2.Text = MySqlLib.MySqlData.MySqlExecute.CreateBD();
        
        if (res.HasError == false)
        {
            Label1.Text = Convert.ToString("MySql online");
            Label1.ForeColor = System.Drawing.Color.Black;
           // Label1.Text = res.ResultText;
            img1.Src = "images/alert.png";
        }
        if (res.HasError == true)
        {
            Label1.Text = Convert.ToString("MySql offline");
            Label1.ForeColor = System.Drawing.Color.Red;
            img1.Src = "images/error.png";
        }

      
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        string login = UserName.Text;
        string password = Password.Text;
        string url = "";
        string typeuser = "";
        List<string> otv = new List<string>();
        if (mssql.Login(login, password, "user").Count != 0)
        {
            typeuser = "user";
             otv = mssql.Login(login, password, typeuser);
            url = "~/Patient.aspx";
        }
        if (mssql.Login(login, password, "doctor").Count != 0)
        {
            typeuser = "doctor";
             otv = mssql.Login(login, password, typeuser);
            
            url = "~/Workstop.aspx";
        }
        if (mssql.Login(login, password, "registr").Count != 0)
        {
            typeuser = "registr";
             otv = mssql.Login(login, password, typeuser);
            
            url = "~/Desk.aspx";
        }
        try
        {
            
            
            HttpCookie cookie = new HttpCookie("user");

            cookie["iduser"] = otv[0]; //member.Fio;
            cookie["fiouser"] = otv[1]; //memberDB.GetMemberRole(member.MemberID);
            cookie["typeuser"] = typeuser;
            cookie.Expires = DateTime.Now.AddHours(9);
            Response.Cookies.Add(cookie);

            Response.Redirect(url);




        }
        catch { }
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Response.Redirect("~/logout.aspx");
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        string login = UserName.Text;
        string password = Password.Text;
        string url = "";
        string typeuser = "";
        List<string> otv = new List<string>();
        if (mssql.Login(login, password, "user").Count != 0)
        {
            typeuser = "user";
            otv = mssql.Login(login, password, typeuser);
            url = "~/Patient.aspx";
        }
        if (mssql.Login(login, password, "doctor").Count != 0)
        {
            typeuser = "doctor";
            otv = mssql.Login(login, password, typeuser);

            url = "~/Workstop.aspx";
        }
        if (mssql.Login(login, password, "registr").Count != 0)
        {
            typeuser = "registr";
            otv = mssql.Login(login, password, typeuser);

            url = "~/Desk.aspx";
        }
        try
        {


            HttpCookie cookie = new HttpCookie("user");

            cookie["iduser"] = otv[0]; //member.Fio;
            cookie["fiouser"] = otv[1]; //memberDB.GetMemberRole(member.MemberID);
            cookie["typeuser"] = typeuser;
            cookie.Expires = DateTime.Now.AddHours(9);
            Response.Cookies.Add(cookie);

            Response.Redirect(url);




        }
        catch { }
    }
}