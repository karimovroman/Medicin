using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class visitsnew : System.Web.UI.Page
{
    int idpacient = 0;
    int iddoctor = 0;
    int idosm = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        idosmotr.Text = Convert.ToString(idosm);
        MultiView1.SetActiveView(osmotrnew);
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz> diagnozs = new List<MySqlLib.MySqlData.MySqlExecute.zabdiagnoz>();
        diagnozs = mysql.SelectZabDiagnoz();

        foreach(MySqlLib.MySqlData.MySqlExecute.zabdiagnoz n in diagnozs)
        {
            diagnoz.Items.Add(new ListItem(n.name, Convert.ToString(n.id)));
        }

    }
    protected void SaveMyInformation(object sender, EventArgs e)
    {
        
            DBase.MSSQL mssql = new DBase.MSSQL();
            DBase.osmotr osm = new DBase.osmotr();
            osm.Id = 0;
            osm.Idp = idpacient;
            osm.Idv = iddoctor;
            osm.Result = result.Text;
            osm.Simpt = simptom.Text;
            osm.Comm = about.Text;
            osm.Data = DateTime.Now.ToShortDateString();
            osm.Iddiag = Convert.ToInt32(diagnoz.SelectedValue);
            mssql.InsertOsmotr(osm);
    }
    protected void SaveMyInformationNew(object sender, EventArgs e)
    {

        DBase.MSSQL mssql = new DBase.MSSQL();
        DBase.osmotrn osm = new DBase.osmotrn();
        osm.Id = 0;
        osm.Idosm = Convert.ToInt32(idosmotr.Text);
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