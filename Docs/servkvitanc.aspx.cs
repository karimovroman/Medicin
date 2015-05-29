using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docs_servkvitanc : System.Web.UI.Page
{
    int pacid = 0;
    int visitid = 0;
    int userid = 0;
    string months = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        HttpCookie cookie = Request.Cookies["kvitanc"];
        HttpCookie cookie2 = Request.Cookies["user"];
        userid = Convert.ToInt32(cookie2["iduser"]);
        if (cookie != null)
        {
            pacid = Convert.ToInt32(cookie["pacid"]);
            visitid = Convert.ToInt32(cookie["idvisit"]);
        }
        else
        {
            Response.Redirect("regrecordservice.aspx");
        }
        DBase.patient pac = mssql.Getpatient(pacid);
        List<DBase.servicetime> servicetimes = mssql.GetAllServicesTime();
        List<DBase.service> services = mssql.GetServices();
        List<DBase.mo> molist = mssql.GetMo();
        int mo = mssql.GetRegistratorMO(userid);

        if (DateTime.Now.Month == 1)
            months = "Январь";
        if (DateTime.Now.Month == 2)
            months = "Февраль";
        if (DateTime.Now.Month == 3)
            months = "Март";
        if (DateTime.Now.Month == 4)
            months = "Апрель";
        if (DateTime.Now.Month == 5)
            months = "Май";
        if (DateTime.Now.Month == 6)
            months = "Июнь";
        if (DateTime.Now.Month == 7)
            months = "Июль";
        if (DateTime.Now.Month == 8)
            months = "Август";
        if (DateTime.Now.Month == 9)
            months = "Сентябрь";
        if (DateTime.Now.Month == 10)
            months = "Октябрь";
        if (DateTime.Now.Month == 11)
            months = "Ноябрь";
        if (DateTime.Now.Month == 12)
            months = "Декабрь";
        
        _fio.Text = " " + pac.Fam + " " + pac.Im + " " + pac.Otch + " ";
        _fio2.Text = " " + pac.Fam + " " + pac.Im + " " + pac.Otch + " ";
       
        foreach (DBase.mo m in molist)
            if (m.Id == mo)
            {
                _namemo.Text = m.Name;
                _address.Text = m.Adres;
                _lico.Text = m.Lico;
            }
        foreach (DBase.servicetime st in servicetimes)
            if (st.Id == visitid && st.Idpac == pacid)
            {
                _date2.Text = st.Data;
                _numb.Text = Convert.ToString(DateTime.Now.Day) + "-" + Convert.ToString(st.Id);
                foreach (DBase.service s in services)
                    if (st.Service == s.Id)
                    {
                        _cost.Text = s.Cost;
                        _names.Text = s.Name;
                    }
            }
        _date.Text = DateTime.Now.ToShortDateString();
        
    }
}