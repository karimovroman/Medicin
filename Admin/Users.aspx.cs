using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Users : System.Web.UI.Page
{
    protected void tab0_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 0;
        tab0.BackColor = System.Drawing.Color.LightGray;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
        email.Text = "";
        phone.Text = "";
        rfio.Text = "";
        rname.Text = "";
        rotch.Text = "";
        comm.Text = "";
        regilist.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specss = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();
        specss = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specs = specss.OrderBy(o => o.name).ToList();
        
        DBase.MSSQL ms = new DBase.MSSQL();
        List<DBase.mo> listmos = ms.GetMo();
        List<DBase.mo> molist = listmos.OrderBy(o => o.Name).ToList();
                   
        List<DBase.registr> reglists = ms.GetRegistrat();
        List<DBase.registr> reglist = reglists.OrderBy(o => o.Fio).ToList();
     
        foreach (DBase.registr sd in reglist)
        {
            regilist.Items.Add(new ListItem(sd.Fio, Convert.ToString(sd.Id)));
        }
        List<DBase.doctor> doclists = ms.GetAllDoctors();
        List<DBase.doctor> doclist = doclists.OrderBy(o => o.Name).ToList();
        
        foreach (DBase.doctor sd in doclist)
        {
            doctlist.Items.Add(new ListItem(sd.Sur + " " + sd.Name + " " + sd.Mid, Convert.ToString(sd.Id)));
        }
        mos.Items.Clear();
        mo.Items.Clear();
        foreach (DBase.mo m in molist)
        {
            mos.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
            mo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
        }
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor sd in specs)
        {
            Specs.Items.Add(new ListItem(sd.name, Convert.ToString(sd.id)));
        }
    }
    protected void tab1_Click(object sender, EventArgs e)
    {
        tabsi.ActiveViewIndex = 1;
        tab1.BackColor = System.Drawing.Color.LightGray;

        tab0.BackColor = System.Drawing.Color.WhiteSmoke;
        Name.Text = "";
        Surname.Text = "";
        Midname.Text = "";
        Dolj.Text = "";
        doctlist.Items.Clear();
        kabin.Text = "";
        Specs.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specss = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();
        
        specss = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specs = specss.OrderBy(o => o.name).ToList();
       
        DBase.MSSQL ms = new DBase.MSSQL();
        List<DBase.mo> listmos = ms.GetMo();
        List<DBase.mo> molist = listmos.OrderBy(o => o.Name).ToList();
       
        List<DBase.registr> reglists = ms.GetRegistrat();
        List<DBase.registr> reglist = reglists.OrderBy(o => o.Fio).ToList();
        mos.Items.Clear();
        mo.Items.Clear();
        foreach (DBase.registr sd in reglist)
        {
            regilist.Items.Add(new ListItem(sd.Fio, Convert.ToString(sd.Id)));
        }
        List<DBase.doctor> doclists = ms.GetAllDoctors();
        List<DBase.doctor> doclist = doclists.OrderBy(o => o.Sur).ToList();
        foreach (DBase.doctor sd in doclist)
        {
            doctlist.Items.Add(new ListItem(sd.Sur + " " + sd.Name + " " + sd.Mid, Convert.ToString(sd.Id)));
        }
        foreach (DBase.mo m in molist)
        {
            mos.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
            mo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
        }
        foreach (MySqlLib.MySqlData.MySqlExecute.specdoctor sd in specs)
        {
            Specs.Items.Add(new ListItem(sd.name, Convert.ToString(sd.id)));
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Предворительная очистка
        email.Text = "";
        phone.Text = "";
        rfio.Text = "";
        rname.Text = "";
        rotch.Text = "";
        comm.Text = "";
        mos.Items.Clear();
        mo.Items.Clear();
        regilist.Items.Clear();
        doctlist.Items.Clear();
        MySqlLib.MySqlData.MySqlExecute mysql = new MySqlLib.MySqlData.MySqlExecute();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specss = new List<MySqlLib.MySqlData.MySqlExecute.specdoctor>();

        specss = mysql.SelectSpecDoctor();
        List<MySqlLib.MySqlData.MySqlExecute.specdoctor> specs = specss.OrderBy(o => o.name).ToList();

        DBase.MSSQL ms = new DBase.MSSQL();
        List<DBase.mo> listmos = ms.GetMo();
        List<DBase.mo> molist = listmos.OrderBy(o => o.Name).ToList();

        List<DBase.registr> reglists = ms.GetRegistrat();
        List<DBase.registr> reglist = reglists.OrderBy(o => o.Fio).ToList();
        foreach (DBase.registr sd in reglist)
        {
            regilist.Items.Add(new ListItem(sd.Fio, Convert.ToString(sd.Id)));
        }
        List<DBase.doctor> doclists = ms.GetAllDoctors();
        List<DBase.doctor> doclist = doclists.OrderBy(o => o.Sur).ToList();
        foreach (DBase.doctor sd in doclist)
        {
            doctlist.Items.Add(new ListItem(sd.Sur +" " + sd.Name + " " + sd.Mid, Convert.ToString(sd.Id)));
        }
        foreach(DBase.mo m in molist)
        {
            mos.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
            mo.Items.Add(new ListItem(m.Name, Convert.ToString(m.Id)));
        }
        foreach(MySqlLib.MySqlData.MySqlExecute.specdoctor sd in specs)
        {
            Specs.Items.Add(new ListItem(sd.name, Convert.ToString(sd.id)));
        }
        tabsi.ActiveViewIndex = 0;
        tab0.BackColor = System.Drawing.Color.LightGray;

        tab1.BackColor = System.Drawing.Color.WhiteSmoke;
    }
    protected void savereg_Click(object sender, EventArgs e)
    {
        DBase.MSSQL ms = new DBase.MSSQL();
        string password = new DBase.password().generate();
        int r = ms.InsertRegistrator(password, email.Text, phone.Text, rfio.Text + " " + rname.Text+" " + rotch.Text , comm.Text,Convert.ToInt32(mo.SelectedValue));
        if (r != 0)
        {
            Email.Email emails = new Email.Email();
            emails.SendEmailGmail("medicinsystem@gmail.com", email.Text, "Ваш пароль MedicinSystem", "Ваш пароль: " + password + "/n Храните пароль в секрете. Для смены пароля перейдите по ссылке сменить пароль в ЛК");

            info.Text = "Сотрудник регистратуры успешно добавлен!";
            info.ForeColor = System.Drawing.Color.DarkGreen;
        }
        else
        {
            info.Text = "Сотрудник не добавлен!";
            info.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void savedoc_Click(object sender, EventArgs e)
    {
        DBase.MSSQL ms = new DBase.MSSQL();
        string password = new DBase.password().generate();
        int r = ms.InsertDoctor(new DBase.doctor(1,Name.Text,Surname.Text, Midname.Text,Dolj.Text, mos.SelectedValue ,kabin.Text,Convert.ToInt32(Specs.SelectedValue), Kvalif.SelectedValue));
        if (r!=0)
        {
            ms.InsertDoctorPassword(password, r, demail.Text);
            Email.Email emails = new Email.Email();
            emails.SendEmailGmail("medicinsystem@gmail.com", demail.Text, "Ваш пароль MedicinSystem", "Ваш пароль: " + password + "/n Храните пароль в секрете. Для смены пароля перейдите по ссылке сменить пароль в ЛК");
            info.Text = "Врач успешно добавлен!";
            info.ForeColor = System.Drawing.Color.DarkGreen;
        }
        else
        {
            info.Text = "Врач не добавлен!";
            info.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void deld_Click(object sender, ImageClickEventArgs e)
    {
        DBase.MSSQL ms = new DBase.MSSQL();
        ms.DeleteDoctor(Convert.ToInt32(doctlist.SelectedValue));
       
    }
    protected void delr_Click(object sender, ImageClickEventArgs e)
    {
        DBase.MSSQL ms = new DBase.MSSQL();
        ms.DeleteRegistrator(Convert.ToInt32(regilist.SelectedValue));
        
    }
}