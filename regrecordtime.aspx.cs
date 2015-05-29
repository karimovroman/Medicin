using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regRecordtime : System.Web.UI.Page
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
        HttpCookie cookie = Request.Cookies["medicin"];
        if (cookie != null)
        {
            did = (cookie["regdoctorid"]);

        }
        else
        {
            Response.Redirect("regrecordspec.aspx");
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
        List<DBase.doctordesk> time2 = new List<DBase.doctordesk>();
        time2.Clear();
        time2 = mssql.GetAllDesk(Convert.ToInt32(did));
        //Время приема
        List<DBase.doctordesks> time3 = new List<DBase.doctordesks>();
        time3.Clear();
        time3 = mssql.GetAllDoctorDesk(Convert.ToInt32(did));
      

        /////////////////////////
        if (ch1.Text.Length < 2)
            ch1.Text = "0" + ch1.Text;
        if (ch2.Text.Length < 2)
            ch2.Text = "0" + ch2.Text;
        if (ch3.Text.Length < 2)
            ch3.Text = "0" + ch3.Text;
        if (ch4.Text.Length < 2)
            ch4.Text = "0" + ch4.Text;
        if (ch5.Text.Length < 2)
            ch5.Text = "0" + ch5.Text;
        if (ch6.Text.Length < 2)
            ch6.Text = "0" + ch6.Text;
        if (ch7.Text.Length < 2)
            ch7.Text = "0" + ch7.Text;
        //для ПН
        if (Convert.ToInt32(daycontr.Text) < 5) { 
        if (Convert.ToInt32(ch1.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch1.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch1.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch1.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        }
        if (Convert.ToInt32(ch1.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch1.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch1.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch1.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        pn.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch1.Text) < Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) > 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch1.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch1.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch1.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        pn.Controls.Add(cntrl);
                    }

                }
        }
        //для ВТ
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch2.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch2.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch2.Text) == Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
            {
                ch2.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch2.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch2.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch2.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vt.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch2.Text) < Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) > 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch2.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch2.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vt.Controls.Add(cntrl);
                    }

                }
        }
        //для СР
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch3.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch3.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch3.Text) == Convert.ToInt32(DateTime.Now.Day))
            {
                ch3.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch3.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch2.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch2.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vt.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch3.Text) < Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) > 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch2.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch2.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vt.Controls.Add(cntrl);
                    }

                }
        }
        //для ЧТ
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch4.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch4.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch4.Text) == Convert.ToInt32(DateTime.Now.Day))
            {
                ch4.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch4.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch4.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch4.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch4.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        ht.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch4.Text) < Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) > 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch4.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch4.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch4.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        ht.Controls.Add(cntrl);
                    }

                }
        }
        //для ПТ
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch5.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch5.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch5.Text) == Convert.ToInt32(DateTime.Now.Day))
            {
                ch5.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch5.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch5.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch5.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch5.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        pt.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch5.Text)< Convert.ToInt32(DateTime.Now.Day))
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch5.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch5.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch5.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        pt.Controls.Add(cntrl);
                    }

                }
        }
        //для СБ
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch6.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch6.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch6.Text) == Convert.ToInt32(DateTime.Now.Day))
            {
                ch6.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch6.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch6.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch6.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch6.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        sb.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch6.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch6.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch6.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch6.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        sb.Controls.Add(cntrl);
                    }

                }
        }
        //для ВС
        if (Convert.ToInt32(daycontr.Text) < 7)
        {
            if (Convert.ToInt32(ch7.Text) < Convert.ToInt32(DateTime.Now.Day))
            {
                ch7.ToolTip = "Запись на выбранную дату не ведется";
            }
            if (Convert.ToInt32(ch7.Text) == Convert.ToInt32(DateTime.Now.Day))
            {
                ch7.ToolTip = "Запись на выбранную дату в регистратуре";
            }
        }
        if (Convert.ToInt32(ch7.Text) > Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) < 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch7.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch7.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch7.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vs.Controls.Add(cntrl);
                    }

                }
        }
        if (Convert.ToInt32(ch7.Text) < Convert.ToInt32(DateTime.Now.Day) && Convert.ToInt32(daycontr.Text) > 5)
        {
            foreach (DBase.doctordesks d in time3)
                if (d.Data.Substring(0, 2) == ch7.Text)
                {
                    int y = 0;
                    foreach (DBase.doctordesk dd in time2)
                    {
                        if (d.Data == dd.Data && d.Time == dd.Time)
                            y = 1;
                    }
                    if (y == 0)
                    {
                        string mon = "";
                        Templates_regtimer cntrl = new Templates_regtimer();
                        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
                        cntrl.Times = d.Time;
                        mon = Convert.ToString(DateTime.Now.Month);
                        if (Convert.ToInt32(ch7.Text) < 14 && DateTime.Now.Day > 14)
                            mon = Convert.ToString(DateTime.Now.Month + 1);
                        if (mon.Length == 1)
                            mon = "0" + mon;
                        cntrl.Data = ch7.Text + "." + mon + "." + DateTime.Now.Year;
                        cntrl.Month = Convert.ToString(DateTime.Now.Month);
                        vs.Controls.Add(cntrl);
                    }

                }
        }
        /////////////////////////
        ////для ПН
        //foreach(DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch1.Text)
        //{
        //    int y = 0;
        //    foreach(DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if(y == 0)
        //    {
        //        string mon= "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if(Convert.ToInt32(ch1.Text)<14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch1.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        pn.Controls.Add(cntrl);
        //    }

        //}
            
                

        //для ВТ

        //foreach (DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch2.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch2.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch2.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        vt.Controls.Add(cntrl);
        //    }

        //}
        //для СР
        //foreach (DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch3.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch3.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch3.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        sr.Controls.Add(cntrl);
        //    }

        //}
        //для ЧТ
        //foreach (DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch4.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch4.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch4.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        ht.Controls.Add(cntrl);
        //    }

        //}
        //для ПТ
        //foreach (DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch5.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch5.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch5.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        pt.Controls.Add(cntrl);
        //    }

        //}
        //для СБ
        //foreach (DBase.doctordesks d in time3)
        //    if (d.Data.Substring(0, 2) == ch6.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch6.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch6.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        sb.Controls.Add(cntrl);
        //    }

        //}
        //для ВС
        //foreach (DBase.doctordesks d in time3)
        //    if(d.Data.Substring(0,2) == ch7.Text)
        //{
        //    int y = 0;
        //    foreach (DBase.doctordesk dd in time2)
        //    {
        //        if (d.Data == dd.Data && d.Time == dd.Time)
        //            y = 1;
        //    }
        //    if (y == 0)
        //    {
        //        string mon = "";
        //        Templates_regtimer cntrl = new Templates_regtimer();
        //        cntrl = (Templates_regtimer)LoadControl("Templates/regtimer.ascx");
        //        cntrl.Times = d.Time;
        //        mon = Convert.ToString(DateTime.Now.Month);
        //        if (Convert.ToInt32(ch7.Text) < 14 && DateTime.Now.Day > 14)
        //            mon = Convert.ToString(DateTime.Now.Month + 1);
        //        if (mon.Length == 1)
        //            mon = "0" + mon;
        //        cntrl.Data = ch7.Text + "." + mon + "." + DateTime.Now.Year;
        //        cntrl.Month = Convert.ToString(DateTime.Now.Month);
        //        vs.Controls.Add(cntrl);
        //    }

        //}

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

      // Page_Load(new object(), new EventArgs());
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
}