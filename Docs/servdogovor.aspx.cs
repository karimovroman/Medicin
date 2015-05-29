using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docs_servdogovor : System.Web.UI.Page
{
    int pacid = 0;
    int visitid = 0;
    int userid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBase.MSSQL mssql = new DBase.MSSQL();
        HttpCookie cookie = Request.Cookies["dogovor"];
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

        _passer.Text = Convert.ToString(pac.Sernom).Substring(0, 4);
        _pasnom.Text = Convert.ToString(pac.Sernom).Substring(4, 6);
        _year.Text = Convert.ToString(DateTime.Now.Year);
        if (DateTime.Now.Month == 1)
            _month.Text = "Январь";
        if (DateTime.Now.Month == 2)
            _month.Text = "Февраль";
        if (DateTime.Now.Month == 3)
            _month.Text = "Март";
        if (DateTime.Now.Month == 4)
            _month.Text = "Апрель";
        if (DateTime.Now.Month == 5)
            _month.Text = "Май";
        if (DateTime.Now.Month == 6)
            _month.Text = "Июнь";
        if (DateTime.Now.Month == 7)
            _month.Text = "Июль";
        if (DateTime.Now.Month == 8)
            _month.Text = "Август";
        if (DateTime.Now.Month == 9)
            _month.Text = "Сентябрь";
        if (DateTime.Now.Month == 10)
            _month.Text = "Октябрь";
        if (DateTime.Now.Month == 11)
            _month.Text = "Ноябрь";
        if (DateTime.Now.Month == 12)
            _month.Text = "Декабрь";
        _day.Text = Convert.ToString(DateTime.Now.Day);
        _vidan.Text = pac.Kemv;
        _fiopac.Text = " " + pac.Fam + " " + pac.Im + " " + pac.Otch + " ";
        _fiopac2.Text = " " + pac.Fam + " " + pac.Im.Substring(0, 1) + "." + pac.Otch.Substring(0, 1) + ". ";
        _fiozak.Text = " " + pac.Fam + " " + pac.Im.Substring(0, 1) + "." + pac.Otch.Substring(0, 1) + ". ";
        foreach(DBase.mo m in molist)
            if(m.Id == mo)
                {
                    _namemo.Text = m.Name;
                    _address.Text = m.Adres;
                    _bik.Text = m.Bik;
                    _inn.Text = m.Inn;
                    _kpp.Text = m.Kpp;
                    _licenz.Text = m.Licenz;
                    _lico.Text = m.Lico;
                    _phone.Text = m.Phone;
                }
        foreach(DBase.servicetime st in servicetimes)
            if(st.Id == visitid && st.Idpac == pacid)
            {
                foreach(DBase.service s in services)
                    if(st.Service == s.Id)
                    {
                        _cost.Text = s.Cost;
                        _cost2.Text = s.Cost;
                    }
            }
        _numberdog.Text = Convert.ToString(DateTime.Now.Day)+"/"+Convert.ToString(DateTime.Now.Month)+"/"+Convert.ToString(DateTime.Now.Year)+"-" + Convert.ToString(visitid);
    }
}