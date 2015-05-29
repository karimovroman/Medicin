using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class servicepoint : System.Web.UI.Page
{
    public string serviceid = "";
    public string pacient = "";
    public string emailp = "";
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        DBase.servicetime desk = new DBase.servicetime();
        desk.Idpac = Convert.ToInt32(pacient);
        desk.Service = Convert.ToInt32(serviceid);
        desk.Time = times.Text;
        desk.Data = data.Text;
        desk.Id = 0;

        DBase.MSSQL mssql = new DBase.MSSQL();
        mssql.InsertServiceTime(desk);
        if (CheckBox1.Checked == true) { 
        Email.Email email = new Email.Email();
        email.SendEmailGmail("medicinsystem@medicen.com", "roman-kmail@mail.ru", "Информация о вашей записи на прием", "Уважаемый " + pac.Text + ". Вы записаны на " + servname  + " " + data.Text + " на " + times.Text + ". Стоимость услуги " + cost.Text);
        //desk.Code = pat.PatientID + doctorid + datazap.Substring(0, 2) + datazap.Substring(2, 2);
        }

        Response.Redirect("~/Patient.aspx");
       
    }
}