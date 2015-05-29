using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recepts : System.Web.UI.Page
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
                pacsid.Text = cookie["idpatient"];
            }
            else
                Response.Redirect("pacients.aspx");
            HttpCookie cookiee = Request.Cookies["user"];
            if (cookiee != null)
            {
                if(cookiee["typeuser"] == "doctor")
                    docsid.Text = cookiee["iduser"];
            }
            else
                Response.Redirect("pacients.aspx");
            rec.Visible = false;


            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            List<MySqlLib.MySqlData.MySqlExecute.lekarstvo> str = mysql.SelectLekarstvo();
            
            if (str.Count > 0)
            {
                foreach (MySqlLib.MySqlData.MySqlExecute.lekarstvo l in str)
                {

                    lekars.Items.Add(new ListItem(l.name, Convert.ToString(l.id)));
                }

                formavip.Text = str.First().type;
                dozalek.Text = str.First().doza;


            }
            DBase.MSSQL mssql = new DBase.MSSQL();
            List<DBase.patient> patslist = mssql.GetAllPatient();
            
            List<DBase.mo> moslist = mssql.GetMo();
            foreach(DBase.patient pat in patslist)
            {
                if(pat.PatientID == Convert.ToInt32(pacsid.Text))
                    foreach(DBase.mo m in moslist)
                    {
                        if(pat.Mo == m.Id)
                        motext.Text = m.Name;
                    }
           }


        }
    }
   
}