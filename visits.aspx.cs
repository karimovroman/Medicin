using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visits : System.Web.UI.Page
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
            novorojd.Visible=false;
            MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
            List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> diagnozs = new List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz>();
            diagnozs = mysql.SelectZabDiagnoz();

            foreach(MySqlLib.MySqlData.MySqlExecute.zabdiagnoz n in diagnozs)
            {
                diagnoz.Items.Add(new ListItem(n.name, Convert.ToString(n.id)));
            }
            DBase.MSSQL mssql = new DBase.MSSQL();
            List<DBase.patient> pacs = mssql.GetAllPatient();
            foreach(DBase.patient pt in pacs)
                if (pt.PatientID == Convert.ToInt32(pacid))
                {
                    information.Text = "Пациент: " + pt.Fam + " " + pt.Im.Substring(0, 1) + "." + pt.Otch.Substring(0, 1);
                }
        }
    }
    protected void SaveMyInformation(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["patient"];
        pacid = cookie["idpatient"];
        HttpCookie cookiee = Request.Cookies["user"];
        if (cookiee != null)
        {
            if (cookiee["typeuser"] == "doctor")
                docid = cookiee["iduser"];
        }
        

            DBase.MSSQL mssql = new DBase.MSSQL();
            DBase.osmotr os = new DBase.osmotr();
            os.Id = 0;
            os.Idp = Convert.ToInt32(pacid);
            os.Idv = Convert.ToInt32(docid);
            os.Result = result.Text;
            os.Simpt = simptom.Text;
            os.Comm = about.Text;
            os.Data = DateTime.Now.ToShortDateString();
            os.Iddiag = Convert.ToInt32(diagnoz.SelectedValue);
            int numosm = mssql.InsertOsmotr(os);
        
            if(CheckBox1.Checked == true)
            {
               
                DBase.osmotrn osm = new DBase.osmotrn();
                osm.Id = 0;
                osm.Idosm = Convert.ToInt32(numosm);
                osm.Den = Convert.ToInt32(den.Text);
                osm.Temp = temp.Text;
                osm.Ves = vestela.Text;
                osm.Comm = about.Text;
                osm.Dinamica = dinamica.Text;
                osm.Sost = sost.Text;
                osm.Poroki = poroki.Text;
                osm.Minpor = minporoki.Text;
                osm.Poza = poza.Text;
                osm.Tonys = tonys.Text;
                osm.Refleks = refleks.Text;
                osm.Chss = chastota.Text;
                osm.Dihan = minporoki.Text;
                osm.Pol = pol.Text;
                osm.Jalob = jalob.Text;
                osm.Zabolev = zabolev.Text;
                osm.Dop = dop.Text;
                osm.Osoben = osoben.Text;
                mssql.InsertOsmotrNew(osm);
            }
    }
    
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckBox1.Checked==true)
        {
            novorojd.Visible = true;
        }
        else
        {
            novorojd.Visible = false;
        }

    }
}