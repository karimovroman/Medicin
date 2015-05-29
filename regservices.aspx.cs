using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regservices : System.Web.UI.Page
{
    public int next1 = 0;
    public int prev1 = 0;
    public int serviceid = 1;
    DBase.MSSQL mssql = new DBase.MSSQL();
    void Page_Load(Object sender, EventArgs e)
    {
        
        //if (!IsPostBack)
        //{
            string did = "";
            HttpCookie cookie = Request.Cookies["service"];
            if (cookie != null)
            {
                serviceid = Convert.ToInt32(cookie["serviceid"]);

            }
            else
            {
                Response.Redirect("services.aspx");
            }


            DBase.MSSQL mssql = new DBase.MSSQL();
            string date = DateTime.Now.ToShortDateString();
            string times = DateTime.Now.ToShortTimeString();
            int dayofweek = Convert.ToInt32(DateTime.Now.DayOfWeek);
            int day = Convert.ToInt32(DateTime.Now.Day) + Convert.ToInt32(daycontr.Text);
            
            if (DateTime.Now.Month == 1)
                month.Text = "Январь";
            if (DateTime.Now.Month == 2)
                month.Text = "Февраль";
            if (DateTime.Now.Month == 3)
                month.Text = "Март";
            if (DateTime.Now.Month == 4)
                month.Text = "Апрель";
            if (DateTime.Now.Month == 5)
            { 
                month.Text = "Май";
                if (day > 31)
                    day = day - 31;
            }
            if (DateTime.Now.Month == 6)
            {
                month.Text = "Июнь";
                if (day > 30)
                    day = day - 30;
            }
            if (DateTime.Now.Month == 7)
                month.Text = "Июль";
            if (DateTime.Now.Month == 8)
                month.Text = "Август";
            if (DateTime.Now.Month == 9)
                month.Text = "Сентябрь";
            if (DateTime.Now.Month == 10)
                month.Text = "Октябрь";
            if (DateTime.Now.Month == 11)
                month.Text = "Ноябрь";
            if (DateTime.Now.Month == 12)
                month.Text = "Декабрь";

            int dim = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            if (day - (dayofweek - 1) > dim)
                day = 2;
            ch1.Text = Convert.ToString(day - (dayofweek - 1));
            if (day + 1 - (dayofweek - 1) > dim)
                day = 2;
            ch2.Text = Convert.ToString(day + 1 - (dayofweek - 1));
            if (day + 2 - (dayofweek - 1) > dim)
                day = 2;
            ch3.Text = Convert.ToString(day + 2 - (dayofweek - 1));
            if (day + 3 - (dayofweek - 1) > dim)
                day = 2;
            ch4.Text = Convert.ToString(day + 3 - (dayofweek - 1));
            if (day + 4 - (dayofweek - 1) > dim)
                day = 2;
            ch5.Text = Convert.ToString(day + 4 - (dayofweek - 1));
            if (day + 5 - (dayofweek - 1) > dim)
                day = 2;
            ch6.Text = Convert.ToString(day + 5 - (dayofweek - 1));
            if (day + 6 - (dayofweek - 1) > dim)
                day = 2;
            ch7.Text = Convert.ToString(day + 6 - (dayofweek - 1));

            //Время приема
            List<string> time = new List<string>();
            time.Clear();
            time.Add("08:00");
            time.Add("08:30");
            time.Add("09:00");
            time.Add("09:30");
            time.Add("10:00");
            time.Add("10:30");
            time.Add("11:00");
            time.Add("11:30");
            time.Add("12:00");
            time.Add("12:30");
            time.Add("14:00");
            time.Add("14:30");
            time.Add("15:00");
            time.Add("15:30");
            //Время занятое
            List<DBase.servicetime> time2 = new List<DBase.servicetime>();
            time2.Clear();
            time2 = mssql.GetAllServiceTime(serviceid);
            //Заполняем время
           

            //для ПН
            if (Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 1 || Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 2 || Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 3 || Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 4)
             for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                        cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch1.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        pn.Controls.Add(cntrl);
                    }
                }
            
            //для ВТ
            if (Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 1 || Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 2 || Convert.ToInt32(ch1.Text) != DateTime.Now.Day - 3)
             for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                         cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        vt.Controls.Add(cntrl); 
                    }
                }
            
            //для СР
             for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                         cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch3.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        sr.Controls.Add(cntrl); 
                    }
                }
            
            //для ЧТ
            
                for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                        cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r]; 
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch4.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        ht.Controls.Add(cntrl); 
                    }
                }
            
            //для ПТ
              for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                        cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch5.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        pt.Controls.Add(cntrl); 
                    }
                }
            
            //для СБ
                for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                        cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch6.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        sb.Controls.Add(cntrl); 
                    }
                }
            
            //для ВС
            
                for (int r = 0; r < time.Count(); r++)
                {
                    int yes = 0;
                    foreach (DBase.servicetime st in time2)
                    {
                        if (st.Data.Substring(0, 2) == Convert.ToString(day) && st.Data.Substring(5, 1) == Convert.ToString(DateTime.Now.Month))
                        {
                            yes = 1;
                        }
                        else
                            yes = 0;
                    }
                    if (yes != 1)
                    {
                        Templates_tt cntrl = new Templates_tt();
                        cntrl = (Templates_tt)LoadControl("Templates/timer.ascx");
                        cntrl.Times = time[r];
                        string mon = Convert.ToString(DateTime.Now.Month);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch7.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        
                        //cntrl.Id_spec = Convert.ToString(n.id);
                        vs.Controls.Add(cntrl);
                         
                    }

                }
            


        //}
    }   
    /// <summary>
    /// Срабатывает при нажатии "следующая" неделя
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void next_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(daycontr.Text) < 14)
            daycontr.Text = Convert.ToString(Convert.ToInt32(daycontr.Text) + 7);
        //Page_Load(new object(),new EventArgs());
    }
    /// <summary>
    /// Срабатывает при нажатии "предыдущая" неделя
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void prev_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(daycontr.Text) > 0)
            daycontr.Text = Convert.ToString(Convert.ToInt32(daycontr.Text) - 7);
        //Page_Load(new object(), new EventArgs());
    }
    protected void sd_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("servicetime");
        
        Response.Cookies.Add(cookie);
        Response.Redirect("servicepoint.aspx");
    }
}