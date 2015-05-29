using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_doctor : System.Web.UI.Page
{
    public int next1 = 0;
    public int prev1 = 0;
    public int serviceid = 1;
    public string mon = "";
    DBase.MSSQL mssql = new DBase.MSSQL();
    public int dayofweeks = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
           
        }
       
        if(!IsPostBack)
        {
            dayofweeks = 7;
        List<DBase.doctor> ald = new DBase.MSSQL().GetAllDoctors();
        List<DBase.doctor> alld = ald.OrderBy(o => o.Name).ToList();
        List<DBase.mo> moss = new DBase.MSSQL().GetMo();
        List<DBase.mo> mos = moss.OrderBy(o => o.Name).ToList();
        doctorsselect.Items.Clear();
        molist.Items.Clear();
        foreach (DBase.doctor d in alld)
        {
            doctorsselect.Items.Add(new ListItem(d.Sur+" " + d.Name + " " + d.Mid + ". " +d.Dolj, Convert.ToString( d.Id) ));
        }
        foreach (DBase.mo m in mos)
        {
            molist.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
        }
      
       

        ///////////////////////////////////////////
       
        string date = DateTime.Now.ToShortDateString();
        string times = DateTime.Now.ToShortTimeString();
        int dayofweek = Convert.ToInt32(DateTime.Now.DayOfWeek);
        int day = Convert.ToInt32(DateTime.Now.Day) ;
        if (DateTime.Now.Month == 1)
        {
            month.Text = "Январь";
            mon = "01";
        }
        if (DateTime.Now.Month == 2){
            month.Text = "Февраль"; mon = "02";
        }
        if (DateTime.Now.Month == 3){
            month.Text = "Март"; mon = "03";
        }
        if (DateTime.Now.Month == 4){
            month.Text = "Апрель"; mon = "04";
        }
        if (DateTime.Now.Month == 5){
            month.Text = "Май"; mon = "05";
        }
        if (DateTime.Now.Month == 6){
            month.Text = "Июнь"; mon = "06";
        }
        if (DateTime.Now.Month == 7){
            month.Text = "Июль"; mon = "07";
        }
        if (DateTime.Now.Month == 8){
            month.Text = "Август"; mon = "08";
        }
        if (DateTime.Now.Month == 9){
            month.Text = "Сентябрь"; mon = "09";
        }
        if (DateTime.Now.Month == 10){
            month.Text = "Октябрь"; mon = "10";
        }
        if (DateTime.Now.Month == 11){
            month.Text = "Ноябрь"; mon = "11";
        }
        if (DateTime.Now.Month == 12)
        {
            month.Text = "Декабрь"; mon = "12";
        }

        int dim = DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month);
        if (day - (dayofweek - 1) > dim)
            day = 1;
        ch1.Text = Convert.ToString(day - (dayofweek - 1));
        if (day +1 - (dayofweek - 1) > dim)
            day = 1;
            ch2.Text = Convert.ToString(day + 1 - (dayofweek - 1));
            if (day+2 - (dayofweek - 1) > dim)
                day = 1;
            ch3.Text = Convert.ToString(day + 2 - (dayofweek - 1));
            if (day+3 - (dayofweek - 1) > dim)
                day = 1;
            ch4.Text = Convert.ToString(day + 3 - (dayofweek - 1));
            if (day+4 - (dayofweek - 1) > dim)
                day = 1;
            ch5.Text = Convert.ToString(day + 4 - (dayofweek - 1));
            if (day+5 - (dayofweek - 1) > dim)
                day = 1;
            ch6.Text = Convert.ToString(day + 5 - (dayofweek - 1));
            if (day+6 - (dayofweek - 1) > dim)
                day = 1;
            ch7.Text = Convert.ToString(day + 6 - (dayofweek - 1));

        day = Convert.ToInt32(DateTime.Now.Day) + 7;
        if (day - (dayofweek - 1) > dim - 1)
        {
            day = 1;


            ch11.Text = Convert.ToString(day );
        }
        if (day + 1 - (dayofweek - 1) > dim)
            day = 1;
        ch22.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 1);
      
        ch33.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 2);

        ch44.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 3);

        ch55.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 4);

        ch66.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 5);

        ch77.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 6);

    
        ch111.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 7);
   
        ch222.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 8);
  
        ch333.Text = Convert.ToString(Convert.ToInt32(ch11.Text) +9);
 
        ch444.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 10);
        
        ch555.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 11);
     
        ch666.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 12);
     
        ch777.Text = Convert.ToString(Convert.ToInt32(ch11.Text) + 13);
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
        if (ch11.Text.Length < 2)
            ch11.Text = "0" + ch11.Text;
        if (ch22.Text.Length < 2)
            ch22.Text = "0" + ch22.Text;
        if (ch33.Text.Length < 2)
            ch33.Text = "0" + ch33.Text;
        if (ch44.Text.Length < 2)
            ch44.Text = "0" + ch44.Text;
        if (ch55.Text.Length < 2)
            ch55.Text = "0" + ch55.Text;
        if (ch66.Text.Length < 2)
            ch66.Text = "0" + ch66.Text;
        if (ch77.Text.Length < 2)
            ch77.Text = "0" + ch77.Text;
        if (ch111.Text.Length < 2)
            ch111.Text = "0" + ch111.Text;
        if (ch222.Text.Length < 2)
            ch222.Text = "0" + ch222.Text;
        if (ch333.Text.Length < 2)
            ch333.Text = "0" + ch333.Text;
        if (ch444.Text.Length < 2)
            ch444.Text = "0" + ch444.Text;
        if (ch555.Text.Length < 2)
            ch555.Text = "0" + ch555.Text;
        if (ch666.Text.Length < 2)
            ch666.Text = "0" + ch666.Text;
        if (ch777.Text.Length < 2)
            ch777.Text = "0" + ch777.Text;
        
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
        time.Add("16:00");
        time.Add("16:30");
        time.Add("17:00");
        time.Add("17:30");
        ///////////////////
        //Заполняем время//
        ///////////////////

        pn.Items.Clear();
        vt.Items.Clear();
        sr.Items.Clear();
        ht.Items.Clear();
        pt.Items.Clear();
        sb.Items.Clear();
        vs.Items.Clear();
        pn2.Items.Clear();
        vt2.Items.Clear();
        sr2.Items.Clear();
        ht2.Items.Clear();
        pt2.Items.Clear();
        sb2.Items.Clear();
        vs2.Items.Clear();
        pn3.Items.Clear();
        vt3.Items.Clear();
        sr3.Items.Clear();
        ht3.Items.Clear();
        pt3.Items.Clear();
        sb3.Items.Clear();
        vs3.Items.Clear();
        //для ПН
        if (Convert.ToInt32(ch1.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch1.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch1.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch1.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch1.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                pn.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВТ
        if (Convert.ToInt32(ch2.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch2.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch2.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch2.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch2.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                vt.Items.Add(new ListItem(time[r]));
            }
        }
        //для СР
        if (Convert.ToInt32(ch3.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch3.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch3.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch3.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch3.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                sr.Items.Add(new ListItem(time[r]));
            }
        }
        //для ЧТ
        if (Convert.ToInt32(ch4.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch4.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch4.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch4.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch4.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                ht.Items.Add(new ListItem(time[r]));
            }
        }
        //для ПТ
        if (Convert.ToInt32(ch5.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch5.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch5.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch5.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch5.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                pt.Items.Add(new ListItem(time[r]));
            }
        }
        //для СБ
        if (Convert.ToInt32(ch6.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch6.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch6.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch6.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch6.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                sb.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВС
        if (Convert.ToInt32(ch7.Text) < Convert.ToInt32(DateTime.Now.Day))
        {
            ch7.ToolTip = "Запись на выбранную дату не ведется";
        }
        if (Convert.ToInt32(ch7.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch7.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        if (Convert.ToInt32(ch7.Text) > Convert.ToInt32(DateTime.Now.Day))
        {
            for (int r = 0; r < time.Count(); r++)
            {
                vs.Items.Add(new ListItem(time[r]));
            }
        }


        /////
        //для ПН
        if (Convert.ToInt32(ch11.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch11.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else {
            for (int r = 0; r < time.Count(); r++)
            {
                pn2.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВТ
       if (Convert.ToInt32(ch22.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch22.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else {
            for (int r = 0; r < time.Count(); r++)
            {
                vt2.Items.Add(new ListItem(time[r]));
            }
        }
        //для СР
       if (Convert.ToInt32(ch33.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch33.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else{
            for (int r = 0; r < time.Count(); r++)
            {
                sr2.Items.Add(new ListItem(time[r]));
            }
        }
        //для ЧТ
        if (Convert.ToInt32(ch44.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch44.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else {
            for (int r = 0; r < time.Count(); r++)
            {
                ht2.Items.Add(new ListItem(time[r]));
            }
        }
        //для ПТ
       if (Convert.ToInt32(ch55.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch55.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else{
            for (int r = 0; r < time.Count(); r++)
            {
                pt2.Items.Add(new ListItem(time[r]));
            }
        }
        //для СБ
       if (Convert.ToInt32(ch66.Text) == Convert.ToInt32(DateTime.Now.Day)+7)
        {
            ch66.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else {
            for (int r = 0; r < time.Count(); r++)
            {
                sb2.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВС
        if (Convert.ToInt32(ch77.Text) == Convert.ToInt32(DateTime.Now.Day))
        {
            ch77.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else{
            for (int r = 0; r < time.Count(); r++)
            {
                vs2.Items.Add(new ListItem(time[r]));
            }
        }
            ///////
        //для ПН
        if (Convert.ToInt32(ch111.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch111.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else{
            for (int r = 0; r < time.Count(); r++)
            {
                pn3.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВТ
        if (Convert.ToInt32(ch222.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch222.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else{
            for (int r = 0; r < time.Count(); r++)
            {
                vt3.Items.Add(new ListItem(time[r]));
            }
        }
        //для СР
       if (Convert.ToInt32(ch333.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch333.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else {
            for (int r = 0; r < time.Count(); r++)
            {
                sr3.Items.Add(new ListItem(time[r]));
            }
        }
        //для ЧТ
        if (Convert.ToInt32(ch444.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch444.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else{
            for (int r = 0; r < time.Count(); r++)
            {
                ht3.Items.Add(new ListItem(time[r]));
            }
        }
        //для ПТ
        if (Convert.ToInt32(ch555.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch555.ToolTip = "Запись на выбранную дату в регистратуре";
        }
        else   {
            for (int r = 0; r < time.Count(); r++)
            {
                pt3.Items.Add(new ListItem(time[r]));
            }
        }
        //для СБ
         if (Convert.ToInt32(ch666.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch666.ToolTip = "Запись на выбранную дату в регистратуре";
        }
         else  {
            for (int r = 0; r < time.Count(); r++)
            {
                sb3.Items.Add(new ListItem(time[r]));
            }
        }
        //для ВС
       if (Convert.ToInt32(ch777.Text) == Convert.ToInt32(DateTime.Now.Day)+14)
        {
            ch777.ToolTip = "Запись на выбранную дату в регистратуре";
        }
       else{
            for (int r = 0; r < time.Count(); r++)
            {
                vs3.Items.Add(new ListItem(time[r]));
            }
        }

       
       

        
        mon = "05";
        int mo = Convert.ToInt32(molist.SelectedValue);
        int doc = Convert.ToInt32(doctorsselect.SelectedValue);
        List<DBase.doctordesks> desklists = mssql.GetAllDoctorDesk(doc);

        for (int r = 0; r < time.Count(); r++)

            if (pn.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0, 2))
                    {
                        pn.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            pn.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
                    {
                        vt.Items[r].Selected = true;
                    }
                    else
                    {
                        if (vt.Items.Count != 0)
                            vt.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
                    {
                        sr.Items[r].Selected = true;
                    }
                    else
                    {
                        if (sr.Items.Count != 0)
                            sr.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
                    {
                        ht.Items[r].Selected = true;
                    }
                    else
                    {
                        if (ht.Items.Count != 0)
                            ht.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
                    {
                        sb.Items[r].Selected = true;
                    }
                    else
                    {
                        if (sb.Items.Count != 0)
                            sb.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
                    {
                        pt.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pt.Items.Count != 0)
                            pt.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
                    {
                        vs.Items[r].Selected = true;
                    }
                    else
                    {
                        if (vs.Items.Count != 0)
                            vs.Items[r].Selected = false;
                    }
                }

        ///////2
        for (int r = 0; r < time.Count(); r++)

            if (pn2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
                    {
                        pn2.Items[r].Selected = true;
                    }
                    else
                    {

                        pn2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
                    {
                        vt2.Items[r].Selected = true;
                    }
                    else
                    {

                        vt2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
                    {
                        sr2.Items[r].Selected = true;
                    }
                    else
                    {
                        sr2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
                    {
                        ht2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            ht2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
                    {
                        sb2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            sb2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
                    {
                        pt2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            pt2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
                    {
                        vs2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            vs2.Items[r].Selected = false;
                    }
                }
        /////3
        for (int r = 0; r < time.Count(); r++)

            if (pn3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
                    {
                        pn3.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                            pn3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
                    {
                        vt3.Items[r].Selected = true;
                    }
                    else
                    {
                        vt3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
                    {
                        sr3.Items[r].Selected = true;
                    }
                    else
                    {
                        sr3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
                    {
                        ht3.Items[r].Selected = true;
                    }
                    else
                    {
                        ht3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
                    {
                        sb3.Items[r].Selected = true;
                    }
                    else
                    {
                        sb3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
                    {
                        pt3.Items[r].Selected = true;
                    }
                    else
                    {
                        pt3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
                    {
                        vs3.Items[r].Selected = true;
                    }
                    else
                    {
                        vs3.Items[r].Selected = false;
                    }
                }


            ////////////////////////
        //for (int r = 0; r < time.Count(); r++)

        //    if (pn.Items.Count > 0)
        //        foreach(DBase.doctordesks dd in desklists )
        //    {
        //        if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0,2))
        //        {
        //            pn.Items[r].Selected = true;
        //        }
        //    }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vt.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
        //            {
        //                vt.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sr.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
        //            {
        //                sr.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (ht.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
        //            {
        //                ht.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sb.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
        //            {
        //                sb.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (pt.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
        //            {
        //                pt.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vs.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
        //            {
        //                vs.Items[r].Selected = true;
        //            }
        //        }

        /////////2
        //for (int r = 0; r < time.Count(); r++)

        //    if (pn2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
        //            {
        //                pn2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vt2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
        //            {
        //                vt2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sr2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
        //            {
        //                sr2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (ht2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
        //            {
        //                ht2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sb2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
        //            {
        //                sb2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (pt2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
        //            {
        //                pt2.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vs2.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
        //            {
        //                vs2.Items[r].Selected = true;
        //            }
        //        }
        ///////3
        //for (int r = 0; r < time.Count(); r++)

        //    if (pn3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
        //            {
        //                pn3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vt3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
        //            {
        //                vt3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sr3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
        //            {
        //                sr3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (ht3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
        //            {
        //                ht3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (sb3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
        //            {
        //                sb3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (pt3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
        //            {
        //                pt3.Items[r].Selected = true;
        //            }
        //        }
        //for (int r = 0; r < time.Count(); r++)

        //    if (vs3.Items.Count > 0)
        //        foreach (DBase.doctordesks dd in desklists)
        //        {
        //            if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
        //            {
        //                vs3.Items[r].Selected = true;
        //            }
        //        }



        }
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
        if (dayofweeks < 14)
            dayofweeks += 7;
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
        if (dayofweeks >0)
            dayofweeks -= 7;
        //Page_Load(new object(), new EventArgs());
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(doctorsselect.SelectedValue) != 0)
            mssql.DeleteDoctorDesk(Convert.ToInt32(doctorsselect.SelectedValue));
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
        time.Add("16:00");
        time.Add("16:30");
        time.Add("17:00");
        time.Add("17:30");
        for (int r = 1; r < time.Count(); r++)
        {
            if (pn.Items.Count != 0)
                pn.Items[r].Selected = false;
            if (vt.Items.Count != 0)
                vt.Items[r].Selected = false;
            if (sr.Items.Count != 0)
                sr.Items[r].Selected = false;
            if (ht.Items.Count != 0)
                ht.Items[r].Selected = false;
            if (pt.Items.Count != 0)
                pt.Items[r].Selected = false;
            if (sb.Items.Count != 0)
                sb.Items[r].Selected = false;
            if (vs.Items.Count != 0)
                vs.Items[r].Selected = false;
            pn2.Items[r].Selected = false;
            vt2.Items[r].Selected = false;
            sr2.Items[r].Selected = false;
            ht2.Items[r].Selected = false;
            pt2.Items[r].Selected = false;
            sb2.Items[r].Selected = false;
            vs2.Items[r].Selected = false;
            pn3.Items[r].Selected = false;
            vt3.Items[r].Selected = false;
            sr3.Items[r].Selected = false;
            ht3.Items[r].Selected = false;
            pt3.Items[r].Selected = false;
            sb3.Items[r].Selected = false;
            vs3.Items[r].Selected = false;
        }


        mon = "05";
        int mo = Convert.ToInt32(molist.SelectedValue);
        int doc = Convert.ToInt32(doctorsselect.SelectedValue);
        List<DBase.doctordesks> desklists = mssql.GetAllDoctorDesk(doc);

        for (int r = 0; r < time.Count(); r++)

            if (pn.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0, 2))
                    {
                        pn.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
                    {
                        vt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
                    {
                        sr.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
                    {
                        ht.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
                    {
                        sb.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
                    {
                        pt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
                    {
                        vs.Items[r].Selected = true;
                    }
                }

        ///////2
        for (int r = 0; r < time.Count(); r++)

            if (pn2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
                    {
                        pn2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
                    {
                        vt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
                    {
                        sr2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
                    {
                        ht2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
                    {
                        sb2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
                    {
                        pt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
                    {
                        vs2.Items[r].Selected = true;
                    }
                }
        /////3
        for (int r = 0; r < time.Count(); r++)

            if (pn3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
                    {
                        pn3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
                    {
                        vt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
                    {
                        sr3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
                    {
                        ht3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
                    {
                        sb3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
                    {
                        pt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
                    {
                        vs3.Items[r].Selected = true;
                    }
                }


    }
    /// <summary>
    /// Сохранение выбранных дат
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void savedesk_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(doctorsselect.SelectedValue) != 0)
            mssql.DeleteDoctorDesk(Convert.ToInt32(doctorsselect.SelectedValue));
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
        time.Add("16:00");
        time.Add("16:30");
        time.Add("17:00");
        time.Add("17:30");

       
       
        mon = "05";
        int mo = Convert.ToInt32(molist.SelectedValue);
        int doc = Convert.ToInt32(doctorsselect.SelectedValue);
        for (int r = 0; r < time.Count(); r++)
            if(pn.Items.Count > 0)
        {
            if(pn.Items[r].Selected == true)
            {
                 mssql.InsertDoctorDesk(new DBase.doctordesks(0,ch1.Text + "." + mon + "." + DateTime.Now.Year,pn.Items[r].Text,doc,mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
            if (vt.Items.Count > 0)
        {
            if (vt.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch2.Text + "." + mon + "." + DateTime.Now.Year, vt.Items[r].Text, doc, mo));
            }
        } 
        for (int r = 0; r < time.Count(); r++)
            if (sr.Items.Count > 0)
        {
            if (sr.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch3.Text + "." + mon + "." + DateTime.Now.Year, sr.Items[r].Text, doc, mo));
            }
        } 
        for (int r = 0; r < time.Count(); r++)
            if (ht.Items.Count > 0)
        {
            if (ht.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch4.Text + "." + mon + "." + DateTime.Now.Year, ht.Items[r].Text, doc, mo));
            }
        } 
        for (int r = 0; r < time.Count(); r++)
            if (pt.Items.Count > 0)
        {
            if (pt.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch5.Text + "." + mon + "." + DateTime.Now.Year, pt.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
            if (sb.Items.Count > 0)
        {
            if (sb.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch6.Text + "." + mon + "." + DateTime.Now.Year, sb.Items[r].Text, doc, mo));
            }
        } 
        for (int r = 0; r < time.Count(); r++)
            if (vs.Items.Count > 0)
        {
            if (vs.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch7.Text + "." + mon + "." + DateTime.Now.Year, vs.Items[r].Text, doc, mo));
            }
        }


        ///////2
        if (Convert.ToInt32(ch44.Text) < 14)
            mon = "06";

        for (int r = 0; r < time.Count(); r++)
        {
            if (pn2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch11.Text + "." + mon + "." + DateTime.Now.Year, pn2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (vt2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch22.Text + "." + mon + "." + DateTime.Now.Year, vt2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (sr2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch33.Text + "." + mon + "." + DateTime.Now.Year, sr2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (ht2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch44.Text + "." + mon + "." + DateTime.Now.Year, ht2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (pt2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch55.Text + "." + mon + "." + DateTime.Now.Year, pt2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (sb2.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch66.Text + "." + mon + "." + DateTime.Now.Year, sb2.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (vs.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch7.Text + "." + mon + "." + DateTime.Now.Year, vs.Items[r].Text, doc, mo));
            }
        }
        /////3
        if (Convert.ToInt32(ch444.Text) < 14)
            mon = "06";
        for (int r = 0; r < time.Count(); r++)
        {
            if (pn3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch111.Text + "." + mon + "." + DateTime.Now.Year, pn3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (vt3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch222.Text + "." + mon + "." + DateTime.Now.Year, vt3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (sr3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch333.Text + "." + mon + "." + DateTime.Now.Year, sr3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (ht3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch444.Text + "." + mon + "." + DateTime.Now.Year, ht3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (pt3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch555.Text + "." + mon + "." + DateTime.Now.Year, pt3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (sb3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch666.Text + "." + mon + "." + DateTime.Now.Year, sb3.Items[r].Text, doc, mo));
            }
        }
        for (int r = 0; r < time.Count(); r++)
        {
            if (vs3.Items[r].Selected == true)
            {
                mssql.InsertDoctorDesk(new DBase.doctordesks(0, ch777.Text + "." + mon + "." + DateTime.Now.Year, vs3.Items[r].Text, doc, mo));
            }
        }

    }
    protected void doctorsselect_SelectedIndexChanged(object sender, EventArgs e)
    {
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
        time.Add("16:00");
        time.Add("16:30");
        time.Add("17:00");
        time.Add("17:30");
        int doc = Convert.ToInt32(doctorsselect.SelectedValue);
        List<DBase.doctordesks> desklists = mssql.GetAllDoctorDesk(doc);

        for (int r = 0; r < time.Count(); r++)

            if (pn.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0, 2))
                    {
                        pn.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
                    {
                        vt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
                    {
                        sr.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
                    {
                        ht.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
                    {
                        sb.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
                    {
                        pt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
                    {
                        vs.Items[r].Selected = true;
                    }
                }

        ///////2
        for (int r = 0; r < time.Count(); r++)

            if (pn2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
                    {
                        pn2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
                    {
                        vt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
                    {
                        sr2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
                    {
                        ht2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
                    {
                        sb2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
                    {
                        pt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
                    {
                        vs2.Items[r].Selected = true;
                    }
                }
        /////3
        for (int r = 0; r < time.Count(); r++)

            if (pn3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
                    {
                        pn3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
                    {
                        vt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
                    {
                        sr3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
                    {
                        ht3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
                    {
                        sb3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
                    {
                        pt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
                    {
                        vs3.Items[r].Selected = true;
                    }
                }

    }
    protected void refresh_Click(object sender, ImageClickEventArgs e)
    {
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
        time.Add("16:00");
        time.Add("16:30");
        time.Add("17:00");
        time.Add("17:30");


       



        mon = "05";
        int mo = Convert.ToInt32(molist.SelectedValue);
        int doc = Convert.ToInt32(doctorsselect.SelectedValue);
        List<DBase.doctordesks> desklists = mssql.GetAllDoctorDesk(doc);
/*

        for (int r = 0; r < time.Count(); r++)

            if (pn.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0, 2))
                    {
                        pn.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
                    {
                        vt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
                    {
                        sr.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
                    {
                        ht.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
                    {
                        sb.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
                    {
                        pt.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
                    {
                        vs.Items[r].Selected = true;
                    }
                }

        ///////2
        for (int r = 0; r < time.Count(); r++)

            if (pn2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
                    {
                        pn2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
                    {
                        vt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
                    {
                        sr2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
                    {
                        ht2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
                    {
                        sb2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
                    {
                        pt2.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
                    {
                        vs2.Items[r].Selected = true;
                    }
                }
        /////3
        for (int r = 0; r < time.Count(); r++)

            if (pn3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
                    {
                        pn3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
                    {
                        vt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
                    {
                        sr3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
                    {
                        ht3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
                    {
                        sb3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
                    {
                        pt3.Items[r].Selected = true;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
                    {
                        vs3.Items[r].Selected = true;
                    }
                }
        //Время приема*/
     

        for (int r = 1; r < time.Count(); r++)
        {
            if (pn.Items.Count != 0)
                pn.Items[r].Selected = false;
            if (vt.Items.Count != 0)
                vt.Items[r].Selected = false;
            if (sr.Items.Count != 0)
                sr.Items[r].Selected = false;
            if (ht.Items.Count != 0)
                ht.Items[r].Selected = false;
            if (pt.Items.Count != 0)
                pt.Items[r].Selected = false;
            if (sb.Items.Count != 0)
                sb.Items[r].Selected = false;
            if (vs.Items.Count != 0)
                vs.Items[r].Selected = false;
            pn2.Items[r].Selected = false;
            vt2.Items[r].Selected = false;
            sr2.Items[r].Selected = false;
            ht2.Items[r].Selected = false;
            pt2.Items[r].Selected = false;
            sb2.Items[r].Selected = false;
            vs2.Items[r].Selected = false;
            pn3.Items[r].Selected = false;
            vt3.Items[r].Selected = false;
            sr3.Items[r].Selected = false;
            ht3.Items[r].Selected = false;
            pt3.Items[r].Selected = false;
            sb3.Items[r].Selected = false;
            vs3.Items[r].Selected = false;
        }
       
        for (int r = 0; r < time.Count(); r++)

            if (pn.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn.Items[r].Text == dd.Time && ch1.Text == dd.Data.Substring(0, 2))
                    {
                        pn.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        pn.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt.Items[r].Text == dd.Time && ch2.Text == dd.Data.Substring(0, 2))
                    {
                        vt.Items[r].Selected = true;
                    }
                    else
                    {
                        if(vt.Items.Count != 0)
                        vt.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr.Items[r].Text == dd.Time && ch3.Text == dd.Data.Substring(0, 2))
                    {
                        sr.Items[r].Selected = true;
                    }
                    else
                    {
                        if (sr.Items.Count != 0)
                        sr.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht.Items[r].Text == dd.Time && ch4.Text == dd.Data.Substring(0, 2))
                    {
                        ht.Items[r].Selected = true;
                    }
                    else
                    {
                        if (ht.Items.Count != 0)
                        ht.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb.Items[r].Text == dd.Time && ch6.Text == dd.Data.Substring(0, 2))
                    {
                        sb.Items[r].Selected = true;
                    }
                    else
                    {
                        if (sb.Items.Count != 0)
                            sb.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt.Items[r].Text == dd.Time && ch5.Text == dd.Data.Substring(0, 2))
                    {
                        pt.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pt.Items.Count != 0)
                        pt.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs.Items[r].Text == dd.Time && ch7.Text == dd.Data.Substring(0, 2))
                    {
                        vs.Items[r].Selected = true;
                    }
                    else
                    {
                        if (vs.Items.Count != 0)
                        vs.Items[r].Selected = false;
                    }
                }

        ///////2
        for (int r = 0; r < time.Count(); r++)

            if (pn2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn2.Items[r].Text == dd.Time && ch11.Text == dd.Data.Substring(0, 2))
                    {
                        pn2.Items[r].Selected = true;
                    }
                    else
                    {
                        
                        pn2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt2.Items[r].Text == dd.Time && ch22.Text == dd.Data.Substring(0, 2))
                    {
                        vt2.Items[r].Selected = true;
                    }
                    else
                    {
                       
                        vt2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr2.Items[r].Text == dd.Time && ch33.Text == dd.Data.Substring(0, 2))
                    {
                        sr2.Items[r].Selected = true;
                    }
                    else
                    {
                        sr2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht2.Items[r].Text == dd.Time && ch44.Text == dd.Data.Substring(0, 2))
                    {
                        ht2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        ht2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb2.Items[r].Text == dd.Time && ch66.Text == dd.Data.Substring(0, 2))
                    {
                        sb2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        sb2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt2.Items[r].Text == dd.Time && ch55.Text == dd.Data.Substring(0, 2))
                    {
                        pt2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        pt2.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs2.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs2.Items[r].Text == dd.Time && ch77.Text == dd.Data.Substring(0, 2))
                    {
                        vs2.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        vs2.Items[r].Selected = false;
                    }
                }
        /////3
        for (int r = 0; r < time.Count(); r++)

            if (pn3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pn3.Items[r].Text == dd.Time && ch111.Text == dd.Data.Substring(0, 2))
                    {
                        pn3.Items[r].Selected = true;
                    }
                    else
                    {
                        if (pn.Items.Count != 0)
                        pn3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vt3.Items[r].Text == dd.Time && ch222.Text == dd.Data.Substring(0, 2))
                    {
                        vt3.Items[r].Selected = true;
                    }
                    else
                    {
                        vt3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sr3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sr3.Items[r].Text == dd.Time && ch333.Text == dd.Data.Substring(0, 2))
                    {
                        sr3.Items[r].Selected = true;
                    }
                    else
                    {
                        sr3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (ht3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (ht3.Items[r].Text == dd.Time && ch444.Text == dd.Data.Substring(0, 2))
                    {
                        ht3.Items[r].Selected = true;
                    }
                    else
                    {
                        ht3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (sb3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (sb3.Items[r].Text == dd.Time && ch666.Text == dd.Data.Substring(0, 2))
                    {
                        sb3.Items[r].Selected = true;
                    }
                    else
                    {
                        sb3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (pt3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (pt3.Items[r].Text == dd.Time && ch555.Text == dd.Data.Substring(0, 2))
                    {
                        pt3.Items[r].Selected = true;
                    }
                    else
                    {
                        pt3.Items[r].Selected = false;
                    }
                }
        for (int r = 0; r < time.Count(); r++)

            if (vs3.Items.Count > 0)
                foreach (DBase.doctordesks dd in desklists)
                {
                    if (vs3.Items[r].Text == dd.Time && ch777.Text == dd.Data.Substring(0, 2))
                    {
                        vs3.Items[r].Selected = true;
                    }
                    else
                    {
                        vs3.Items[r].Selected = false;
                    }
                }

        Page_Load(new Object(), new EventArgs());
    }
}